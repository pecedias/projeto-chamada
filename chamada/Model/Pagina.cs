using System;

namespace Model
{
    [Serializable]
    public class Pagina
    {

        public int idPagina { get; set; }
        public String url {get; set;}
        public String descricao { get; set; }
        public int? idPai { get; set; }

        public Pagina()
        {

        }

        public Pagina(int idPagina, string url, string descricao, int? idPai)
        {
            this.idPagina = idPagina;
            this.url = url;
            this.descricao = descricao;
            this.idPai = idPai;
        }
    }
}
