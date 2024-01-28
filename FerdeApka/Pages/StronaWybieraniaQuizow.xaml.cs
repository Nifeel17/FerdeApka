using FerdeApka.Classes;

namespace FerdeApka.Pages;

public partial class StronaWybieraniaQuizow : ContentPage
{
	public StronaWybieraniaQuizow()
	{
		InitializeComponent();
		listaQuizow.ItemsSource = new List<ClassaQuizow>
        {
            new ClassaQuizow{ Tytul="Quiz o postaciach", ShortTitle="Poziom: trudny" },

            new ClassaQuizow{ Tytul="Quiz o odcinkach", ShortTitle="Poziom: ³atwy" },

            new ClassaQuizow{ Tytul="Quiz o postaciach 2", ShortTitle="Poziom: œredni" },
            
            new ClassaQuizow{ Tytul="Quiz o autorach", ShortTitle="Poziom: ³atwy" }
        };
	}
}