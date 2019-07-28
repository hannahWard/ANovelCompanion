﻿using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.Bits
{
    public class BitCreateViewModel
    {
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        public int BookId { get; set; }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Bit bit = new Bit
            {
                Title = this.Title,
                Description = this.Description,
                BookId = this.BookId
            };
            repositoryFactory.GetBitRepository().Save(bit);
        }


    }
}
