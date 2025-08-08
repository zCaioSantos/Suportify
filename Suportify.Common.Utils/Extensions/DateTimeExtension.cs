namespace Suportify.Common.Utils.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime PrimeiraHoraDoDia(this DateTime dateTime)
        {
            return dateTime.Date;
        }


        public static DateTime UltimaHoraDoDia(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddMilliseconds(-2);
        }


        public static DateTime PrimeiroDiaDoMes(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }


        public static DateTime UltimoDiaDoMes(this DateTime dateTime)
        {
            DateTime dateParse = new DateTime(dateTime.Year, dateTime.Month, 1);
            dateParse = dateParse.AddMonths(1);
            return dateParse.AddDays(-1);
        }


        public static DateTime ProximoDiaUtil(this DateTime dateTime, List<DateTime> feriados = null)
        {
            while (true)
            {
                if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (feriados == null || !feriados.Any(d => d.ToString("dd/MM/yyyy") == dateTime.ToString("dd/MM/yyyy")))
                    {
                        break;
                    }
                }

                dateTime = dateTime.AddDays(1);
            }

            return dateTime;
        }


        public static DateTime BuscarDataValida(this DateTime dateTime, int dia)
        {
            DateTime ultimoDiaDoMes = dateTime.UltimoDiaDoMes();
            while (ultimoDiaDoMes.Day < dia)
            {
                dia--;
            }

            return new DateTime(ultimoDiaDoMes.Year, ultimoDiaDoMes.Month, dia);
        }

        public static int CalcularIdade(this DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade -= 1;
            }

            return idade;
        }


        public static string DiaDaSemana(this DateTime dateTime)
        {
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "SEGUNDA-FEIRA";

                case DayOfWeek.Tuesday:
                    return "TERÇA-FEIRA";

                case DayOfWeek.Wednesday:
                    return "QUARTA-FEIRA";

                case DayOfWeek.Thursday:
                    return "QUINTA-FEIRA";

                case DayOfWeek.Friday:
                    return "SEXTA-FEIRA";

                case DayOfWeek.Saturday:
                    return "SABADO";

                case DayOfWeek.Sunday:
                    return "DOMINGO";

                default:
                    return "NÃO IDENTIFICADO";
            }
        }


    }
}
