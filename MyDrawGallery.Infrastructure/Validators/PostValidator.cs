using FluentValidation;
using MyDrawGallery.Core.DTOs;
using MyDrawGallery.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyDrawGallery.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(DateTime.Now);
        }
    }
}
