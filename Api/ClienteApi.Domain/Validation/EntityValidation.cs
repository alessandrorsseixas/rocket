using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClienteApi.Valitation
{
    public class EntityValidation<TEntity> : AbstractValidator<TEntity>
    {
        public bool BeAUpdateDateIsValideDate(DateTime? date)
        {
            if (date != null)
            {
                var updateDate = (DateTime)date;
                if (!DateTime.TryParse(updateDate.ToShortDateString(), new CultureInfo("pt-BR"), DateTimeStyles.None, out _))
                    return false;
                return true;
            }
            return true;
        }
        public bool BeAValideDate(string date)
        {

            if (!DateTime.TryParse(date, new CultureInfo("pt-BR"), DateTimeStyles.None, out var data))
                return true;
            return false;
        }


        public bool CompairAValideDate(string initialDate, string finalDate)
        {
            if (DateTime.Parse(finalDate) > DateTime.Parse(initialDate))
                return true;


          return false;
        }




    }
}
