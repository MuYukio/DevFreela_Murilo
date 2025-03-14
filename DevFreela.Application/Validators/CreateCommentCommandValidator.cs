﻿using DevFreela.Application.Commands.CreateComment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator() 
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Descrição  é de 255 caracteres. ");
            
            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .WithMessage("O conteudo não pode ser vazio.");
        }
    }
}
