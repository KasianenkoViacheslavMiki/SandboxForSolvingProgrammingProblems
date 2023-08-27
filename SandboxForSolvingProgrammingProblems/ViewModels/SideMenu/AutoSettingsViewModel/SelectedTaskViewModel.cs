﻿using SandboxForSolvingProgrammingProblems.Infrastructure;
using SandboxForSolvingProgrammingProblems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SandboxForSolvingProgrammingProblems.ViewModels.SideMenu.AutoSettingsModel
{
    class SelectedTaskViewModel : BaseAutoViewModel
    {
        private RequestEvaluation requestEvaluation;
        private Question question;

        private ICommand returnCommand;
        
        public ICommand ReturnCommand
        {
            get
            {
                return returnCommand ?? (returnCommand = new RelayCommand(async obj =>
                {
                    OnReturnToListTask("");
                }));
            }
        }

        //Copy link to requestEvaluation in Heap
        public SelectedTaskViewModel(RequestEvaluation requestEvaluation, Question question)
        {
            this.requestEvaluation = requestEvaluation;
            this.question = question;
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Content));
        }


        public string Title
        {
            get
            {
                return this.question.Title;
            }
        }
        public string Content
        {
            get
            {
                return this.question.Content;
            }
        }

        public int MemoryLimit
        {
            get
            {
                return requestEvaluation.MemoryLimit;
            }
            set
            {
                requestEvaluation.MemoryLimit = value;
                OnPropertyChanged(nameof(MemoryLimit));
            }
        }

        public int TimeLimit
        {
            get
            {
                return requestEvaluation.TimeLimit;
            }
            set
            {
                requestEvaluation.TimeLimit = value;
                OnPropertyChanged(nameof(TimeLimit));
            }
        }
    }
}
