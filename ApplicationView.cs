using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask {
	class ApplicationView {
		public string SelectedCity { get; set; }
		public string SelectedDay { get; set; }

		public List<string> Cities { get; set; }
		public List<string> Days { get; set; }

		public ApplicationView() {
			Cities = new List<string> {
				"Київ", "Львів", "Донецьк", "Житомир", "Одеса"
			};
			Days = new List<string> {
				"Сьогодні", "Завтра", "Післязавтра"
			};
		}
	}
}
