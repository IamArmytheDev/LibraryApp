﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Models
{
	public class Favourite
	{
		[Required]
		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual User? User { get; set; }

		[Required]
		public int BookId { get; set; }
		[ForeignKey("BookId")]
		public virtual Book? Book { get; set; }

	}
}
