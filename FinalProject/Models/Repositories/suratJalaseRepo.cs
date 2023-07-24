using FinalProject.Models.Context;
using FinalProject.Models.Filters;
using System.Collections.Generic;

namespace FinalProject.Models.Repositories
{
    public interface suratJalaseRepo
    {
        void saveSuratJalase(suratJalase surat, List<band> bandha);
        void deleteSuratJalase(suratJalase surat);
        suratJalase findSuratJalase(int suratID);
        void updateSuratJalase(int suratID, suratJalase newSurat);
        List<suratJalase> AllSuratJalaseha();
        List<suratJalase> filterSuratJalaseha(suratJalaseFilter filter);
    }
}
