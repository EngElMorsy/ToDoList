using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.BL.Model;
using ToDo.BL.Model.AuthSeervices;
using ToDo.DAL.Entity;

namespace ToDo.BL.Helper
{
    public class Validator 
        //: AbstractValidator<TD>
    {
        //public Validator()
        //{
             //RuleFor(x => x.Titile).NotNull().NotEmpty().MaximumLength(100).WithMessage("Required Filed");
             //RuleFor(x => x.Description).MaximumLength(500);
             //RuleFor(x => x.IsCompleted).NotNull().NotEmpty();


        //}
    }
    //public class TodoValidator : AbstractValidator<TDVM>
    //{
    //    public TodoValidator()
    //    {
    //        RuleFor(x => x.Titile).NotNull().NotEmpty().MaximumLength(100).WithMessage("Required Filed");
    //        RuleFor(x => x.Description).MaximumLength(500);
    //        RuleFor(x => x.IsCompleted).NotNull().NotEmpty();
    //    }
        
    //}
    //public class UserValidator : AbstractValidator<RegisterVM>
    //{
    //    public UserValidator()
    //    {
    //        RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(50);
    //        RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
    //        RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8);
    //    }
    //}
}