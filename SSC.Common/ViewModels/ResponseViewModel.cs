﻿using SSC.Common.Exceptions;
using System;

namespace SSC.Common.ViewModels
{
    public class ResponseViewModel
    {
        public const string DefaultErrorMessage = "Ha ocurrido un error inesperado. Contacte a su administrador.";

        public bool IsSuccess { get; set; }
        public bool IsError { get { return !String.IsNullOrWhiteSpace(this.ErrorMessage); } }
        public string ErrorMessage { get; set; }

        public static implicit operator ResponseViewModel(bool result)
        {
            var response = new ResponseViewModel();

            if (result)
            {
                response.IsSuccess = result;
            }
            else
            {
                response.ErrorMessage = ResponseViewModel.DefaultErrorMessage;
            }

            return response;
        }

        public static implicit operator ResponseViewModel(string errorMessage)
        {
            var response = new ResponseViewModel();
            response.ErrorMessage = errorMessage;

            return response;
        }

        public static ResponseViewModel RunAndReturn(Action action)
        {
            try
            {
                action();
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }

            return true;
        }

        public static ResponseViewModel<T> RunAndReturn<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (UnprocessableEntityException ex)
            {
                return ex.Message;
            }
        }
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        private T result;
        public T Result
        {
            get { return result; }
            set
            {
                result = value;
                this.IsSuccess = true;
            }
        }

        public static implicit operator ResponseViewModel<T>(string errorMessage)
        {
            var response = new ResponseViewModel<T>();
            response.ErrorMessage = errorMessage;

            return response;
        }

        public static implicit operator ResponseViewModel<T>(T result)
        {
            var response = new ResponseViewModel<T>();
            response.IsSuccess = true;
            response.Result = result;

            return response;
        }
    }
}
