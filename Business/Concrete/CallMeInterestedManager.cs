﻿using Business.Abstract;
using Business.BaseMessage;
using Core.Result.Abstract;
using Core.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class CallMeInterestedManager : ICallMeInterestedService
    {
        private readonly ICallMeInterestedDal _callMeInterestedDal;
        private readonly IValidator<CallMeInterested> _validator;
        public CallMeInterestedManager(ICallMeInterestedDal callMeInterestedDal, IValidator<CallMeInterested> validator)
        {
            _callMeInterestedDal = callMeInterestedDal;
            _validator = validator;
        }

        public IResult Add(CallMeInterestedCreateDto dto)
        {
            var model = CallMeInterestedCreateDto.ToCallMeInterested(dto);
            var validator = _validator.Validate(model);
            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            _callMeInterestedDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);


        }

        public IResult Delete(int id)
        {

            var dataResult = GetById(id);
            if (dataResult.Data == null)
            {
                return new ErrorResult("CallMe entry not found.");
            }

            var data = dataResult.Data;
            data.Deleted = id;

            _callMeInterestedDal.Update(data);
            return new SuccessResult(UIMessages.Deleted_MESSAGE);

        }

        public IDataResult<List<CallMeInterested>> GetAll()
        {

            var result = _callMeInterestedDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<CallMeInterested>>(result);

        }

        public IDataResult<CallMeInterested> GetById(int id)
        {


            var result = _callMeInterestedDal.GetById(id);
            return new SuccessDataResult<CallMeInterested>(result);


        }

        public IResult UpDate(CallMeInterestedUpdateDto dto)
        {

            var model = CallMeInterestedUpdateDto.ToCallMeInterested(dto);
            var validator = _validator.Validate(model);
            string errorMessage = " ";
            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }
            model.LastUpdateDate = DateTime.Now;
            _callMeInterestedDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);

        }

       
    }
}
