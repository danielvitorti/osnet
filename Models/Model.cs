using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace osnet.Models
{
    public class OsNetContext : DbContext
    {

        public OsNetContext(DbContextOptions<OsNetContext> options) : base(options)
        {
        }
        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<OrdemServico> OrdemServico { get; set; }

        public DbSet<TipoOrdemServico> TipoOrdemServico { get; set; }

        public DbSet<Servico> Servico { get; set; }

        public DbSet<Status> Status { get; set; }


        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ordem_servico.db");
        }
    }

    public class Cliente
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Cpf")]
        public string cpf { get; set; }

        [Display(Name = "Cnpj")]
        public string cnpj { get; set; }

        [Display(Name = "Cep")]
        public string enderecoCep { get; set; }

        [Display(Name = "Rua")]
        public string enderecoRua { get; set; }

        [Display(Name = "Número")]
        public string enderecoNumero { get; set; }

        [Display(Name = "Bairro")]
        public string enderecoBairro { get; set; }

        [Display(Name = "Cidade")]
        public string enderecoCidade { get; set; }

        public List<OrdemServico> ClienteOrdemServico { get; set; }

        
    }

    public class OrdemServico
    {   
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string titulo { get; set; }
        [Display(Name = "Resumo")]
        public string resumo { get; set; }
        [Display(Name = "Justificativa")]
        public string justificativa { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Resolução")]
        public string resolucao { get; set; }



        [Display(Name = "Observação")]
        public string observacao { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }

        [Required]
        public int TipoOrdemServicoId {get; set;}

        public TipoOrdemServico tipoOrdemServico {get; set;}

        [Required]
        public int ServicoId{get; set;}

        public Servico servico{get; set;}


        [Required]
        public int StatusId{get; set;}

        public Status status{get; set;}


        [Display(Name = "Início")]
        public System.DateTime dataInicio{get; set;}


        [Display(Name = "Término")]
        public System.DateTime dataTermino{get; set;}
        
        public System.DateTime dataCadastro{get; set;}

        public OrdemServico()
        {
            this.dataCadastro = System.DateTime.Now;

        }
    }


    public class TipoOrdemServico
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome {get; set;}

        public List<OrdemServico> TiposOrdemServico { get; set; }
    }


    public class Servico
    {

        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome {get; set;}

        [Required]
        [Display(Name = "Valor")]
        public float valor{get; set;}

        public List<OrdemServico> Servicos { get; set; }

    }



    public class Status
    {

        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string nome {get; set;}


        public List<OrdemServico> Statuses { get; set; }

    }
}