using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDAuditorias;
using ObjetosAuditoria;
using Excepcoes;
using System.IO;

namespace RegrasNegocio
{
    public class RN
    {
        /// <summary>
        /// Adiciona uma auditoria a lista
        /// </summary>
        /// <param name="a">auditoria a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não a auditoria</returns>
        public static bool InsereAuditoria(Auditoria a)
        {
            try
            {
                Auditorias.InsereAuditorias(a);
                return true;
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
        /// Adiciona uma vulnerabilidade a lista
        /// </summary>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não uma vulnerabilidade</returns>
        public static bool InsereVulnerabilidade(Vulnerabilidade vuln)
        {
            try
            {
                Vulnerabilidades.InsereVulnerabilidades(vuln);
                return true;
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
        /// Adiciona um Colaborador a lista
        /// </summary>
        /// <param name="col">colaborador a ser adicionado</param>
        /// <returns> Devolve true/false consoante adicione ou não o colaborador</returns>
        public static bool InsereColaborador(Colaborador col)
        {
            try
            {
                Colaboradores.InsereColaboradores(col);
                return true;
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
        /// Adiciona um equipamento a lista
        /// </summary>
        /// <param name="col">colaborador a ser adicionado</param>
        /// <returns> Devolve true/false consoante adicione ou não o colaborador</returns>
        public static bool InsereEquipamento(Equipamento equip)
        {
            try
            {
                Equipamentos.InsereEquipamentos(equip);
                return true;
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
        /// Adiciona uma vulnerabilidade a uma auditoria e vice-versa
        /// </summary>
        /// <param name="a">auditoria a ser adicionada</param>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não </returns>
        public static bool InsereVulnerabilidadeAuditoria(Auditoria a, Vulnerabilidade vuln)
        {
            try
            {
                a.InserirVulnAuditoria(vuln);
                vuln.InserirAudVulnerabilidade(a);
                return true;
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
        /// Adiciona um colaborador a uma auditoria
        /// </summary>
        /// <param name="a">auditoria a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não </returns>
        public static bool InsereColaboradorAuditoria(Auditoria a, Colaborador col)
        {
            try
            {
                col.InserirAudColaborador(a);
                return true;
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
        /// Adiciona uma vulnerabilidade a um equipamento e vice-versa
        /// </summary>
        /// <param name="equip">equipamento a ser adicionada</param>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não </returns>
        public static bool InsereVulnerabilidadeEquipamento(Vulnerabilidade vuln, Equipamento equip)
        {
            try
            {
                vuln.InserirEquipVulnerabilidade(equip);
                equip.InserirVulnEquipamento(vuln);
                return true;
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
        /// Resolve vulnerabilidade
        /// </summary>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não </returns>
        public static bool ResolveVulnerabilidade(Vulnerabilidade vuln)
        {
            try
            {
                vuln.ResolveVulnerabilidade();
                Auditorias.RemoveVulnerabilidadeAuditoria(vuln.Codigo);
                Equipamentos.RemoveVulnerabilidadeEquipamento(vuln.Codigo);
                return true;
            }
            catch (VulnerabilidadeInexistenteException e)
            {
                throw new VulnerabilidadeInexistenteException("ERRO! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Altera o estado do Colaborador
        /// </summary>
        /// <param name="vuln">vulnerabilidade a ser adicionada</param>
        /// <returns> Devolve true/false consoante adicione ou não </returns>
        public static bool ResolveColaborador(Colaborador col)
        {
            try
            {
                col.RemoverColaborador();
                return true;
            }
            catch (VulnerabilidadeInexistenteException e)
            {
                throw new VulnerabilidadeInexistenteException("ERRO! " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Guarda os documentos num ficheiro binario
        /// </summary>
        /// <param name="fileName">ficheiro</param>
        public static bool Save(string fileAuditorias, string fileVulnerabilidades, string fileColaboradores, string fileEquipamentos)
        {
            try
            {
                Auditorias.Save(fileAuditorias);
                Colaboradores.Save(fileColaboradores);
                Vulnerabilidades.Save(fileVulnerabilidades);
                Equipamentos.Save(fileEquipamentos);
                return true;
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                throw new IOException("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Carrega os documentos de um ficheiro binario
        /// </summary>
        /// <param name="fileName">ficheiro</param>
        public static bool Load(string fileAuditorias, string fileVulnerabilidades, string fileColaboradores, string fileEquipamentos)
        {
            try
            {
                Auditorias.Load(fileAuditorias);
                Colaboradores.Load(fileColaboradores);
                Vulnerabilidades.Load(fileVulnerabilidades);
                Equipamentos.Load(fileEquipamentos);
                return true;
            }
            catch (FileLoadException e)
            {
                throw new FileLoadException("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                throw new IOException("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("ERRO! " + e.Message);
            }
        }
        /// <summary>
        /// Carrega os documentos de um ficheiro binario
        /// </summary>
        public static bool ApresentarDados()
        {
            Console.WriteLine("\n==============================================================================================");
            Console.WriteLine("                                            MENU                                                ");
            Console.WriteLine("==============================================================================================\n");
            Console.WriteLine("    > Quantidade de Auditorias realizadas:          {0} \n",                         Auditorias.TotalAuditorias());
            Console.WriteLine("    > Auditoria com MAIS vulnerabilidades:          {0}, {1} falha(s), ({2}) \n",    Auditorias.AuditoriaMaisVulnerabilidades().Codigo.ToString(),
                                                                                                                    Auditorias.AuditoriaMaisVulnerabilidades().CodVulns.Count.ToString(),
                                                                                                                    Auditorias.AuditoriaMaisVulnerabilidades().Data.ToShortDateString());
            Console.WriteLine("    > Auditoria com MENOS vulnerabilidades:         {0}, {1} falha(s), ({2}) \n",    Auditorias.AuditoriaMenosVulnerabilidades().Codigo.ToString(),
                                                                                                                    Auditorias.AuditoriaMenosVulnerabilidades().CodVulns.Count.ToString(),
                                                                                                                    Auditorias.AuditoriaMenosVulnerabilidades().Data.ToShortDateString());
            Console.WriteLine("    > Media de vulnerabilidades das auditorias:     {0} \n\n\n",                     Auditorias.MediaVulnerabilidades().ToString());
            Auditorias.ApresentarAuditorias(); Console.WriteLine("");
            Auditorias.ApresentarVulneabilidadesAuditoria(); Console.WriteLine("");
            Colaboradores.ApresentarColaboradores(); Console.WriteLine("");
            Colaboradores.ApresentarAuditoriasColaborador(); Console.WriteLine("");
            Vulnerabilidades.ApresentarVulnerabilidades(); Console.WriteLine("");
            Equipamentos.ApresentarEquipamentos(); Console.WriteLine("");
            Equipamentos.ApresentarVulneabilidadesAuditoria(); Console.WriteLine("");
            return true;
        }

    }
}
