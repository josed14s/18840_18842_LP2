using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepcoes;
/*  -------------------------------------------------
* <copyright file="Equipamento.cs" company="IPCA"/>
* <summary>
*	Trabalho Pratico LP2 2019-2020
*	José Dias       18840
*	Pedro Ferraz    18842
* </summary>
* <author>José Dias & Pedro Ferraz</author>
* <email
*   a18840@alunos.ipca.pt
*   a18842@alunos.ipca.pt
* </email>
* <desc>
*   Equipamento
* </desc>
* -------------------------------------------------
*/

namespace ObjetosAuditoria
{
    [Serializable]
    /// <summary>
    /// classe equipamento
    /// Responsável por tratar de equipamentos
    /// </summary>
    public class Equipamento
    {
        #region Member Variables
        private int codigo;
        private string tipo;
        private string marca;
        private string modelo;
        private DateTime dataAquisicao;
        private List<int> codVulns;              // Conjunto de vulnerabilidades de um equipamento
        private static int countCodigo;     // Contador para o Codigo
        #endregion

        #region Constructors
        static Equipamento()
        {
            countCodigo = 0;
        }
        /// <summary>
        /// Construtor por defeito
        /// </summary>
        public Equipamento()
        {
            this.tipo = "";
            this.codigo = CodigoEquipamento();
            this.marca = "";
            this.modelo = "";
            this.dataAquisicao = DateTime.Now;
            this.codVulns = new List<int>();
        }
        /// <summary>
        /// Construtor com valores
        /// </summary>
        /// <param name="t">tipo de equipamento</param>
        /// <param name="mar">marca do equipamento</param>
        /// <param name="mod">modelo do equipamento</param>
        /// <param name="dat">data de aquisição</param>
        public Equipamento(string t, string mar, string mod, string dat)
        {
            this.tipo = t;
            this.codigo = CodigoEquipamento();
            this.marca = mar;
            this.modelo = mod;
            this.dataAquisicao = DateTime.Parse(dat);
            this.codVulns = new List<int>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Para permitir alterar a data
        /// </summary>
        public DateTime DataAquisicao
        {
            get { return dataAquisicao; }
            set {DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataAquisicao = value;
                }
            }
        }
        /// <summary>
        /// Para permitir verificar o codigo
        /// </summary>
        public int Codigo
        {
            get { return codigo; }
        }
        /// <summary>
        /// Para permitir alterar o tipo
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        /// <summary>
        /// Para permitir alterar o marca
        /// </summary>
        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        /// <summary>
        /// Para permitir alterar o modelo
        /// </summary>
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        /// <summary>
        /// Para permitir verificar o numero de vulnerabilidades
        /// </summary>
        public List<int> CodVulns
        {
            get { return codVulns; }
            set { codVulns = value; }
        }
        #endregion

        #region Functions
        /// <summary>
        /// Determina o código do Equipamento
        /// </summary>
        /// <returns> Devolve o código do equipamento</returns>
        public static int CodigoEquipamento()
        {
            countCodigo++;
            return countCodigo;
        }
        /// <summary>
        /// Para inserir uma vulnerabilidade num equipamento
        /// </summary>
        /// <param name="vuln">Vulnerabilidade a ser inserida</param>
        /// <returns> Devolve o equipamento com a vulnerabilidade adicionada </returns>
        public bool InserirVulnEquipamento(Vulnerabilidade vuln)
        {
            try
            {
                this.codVulns.Add(vuln.Codigo);
                return true;
            }
            catch (VulnerabilidadeInexistenteException e)
            {
                throw new VulnerabilidadeInexistenteException("ERRO! " + e.Message);
            }
            catch (InsercaoException e)
            {
                throw new InsercaoException("ERRO! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Altera o ToString do Equipamento para o formato pretendido
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0,-7}|{1,-15}|{2,-14}|{3,-15}|{4,-20}|{5,-15}", codigo.ToString(),tipo, marca,modelo,dataAquisicao.ToShortDateString(),codVulns.Count.ToString() );
        }
        #endregion

        #region Enums
        #endregion
    }
}
