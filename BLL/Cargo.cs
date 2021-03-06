﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Cargo
    {
        public static string instrucaoSql;




        private int _CodigoCargo;
        private string _NomeCargo;
        private string _Abreviacao;
        private string _DescricaoCargo;
        private int _StatusCargo;

        public int CodigoCargo
        {
            get
            {
                return _CodigoCargo;
            }

            set
            {
                _CodigoCargo = value;
            }
        }

        public string NomeCargo
        {
            get
            {
                return _NomeCargo;
            }

            set
            {
                _NomeCargo = value;
            }
        }

        public string Abreviacao
        {
            get
            {
                return _Abreviacao;
            }

            set
            {
                _Abreviacao = value;
            }
        }

        public string DescricaoCargo
        {
            get
            {
                return _DescricaoCargo;
            }

            set
            {
                _DescricaoCargo = value;
            }
        }

        public int StatusCargo
        {
            get
            {
                return _StatusCargo;
            }

            set
            {
                _StatusCargo = value;
            }
        }

        TCC_Inf2Dm.ClasseParaManipularBancoDeDados c = new TCC_Inf2Dm.ClasseParaManipularBancoDeDados();
              
        public void IncluirComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {
                   new SqlParameter("@NomeCargo",SqlDbType.VarChar) {Value = _NomeCargo },
                   new SqlParameter("@Abreviacao",SqlDbType.VarChar) {Value = _Abreviacao },
                   new SqlParameter("@DescricaoCargo",SqlDbType.VarChar) {Value = _DescricaoCargo },
                    new SqlParameter("@StatusCargo",SqlDbType.Int) {Value = _StatusCargo }
                };
                //criar o objeto 'listaComParametros' a partir da classe 'sqlparameter' definida como uma lista '[]'. Foi instanciado 'new' o objeto 'listaComParametros' com 4 itens/parametros.  Cada parametro foi definido com a identificação '@....' + um tipo de dado 'SqlDbType' +  um valor '{Value = _.....}'
                instrucaoSql = "INSERT INTO tbCargo (NomeCargo, Abreviacao, DescricaoCargo,StatusCargo) VALUES (@NomeCargo, @Abreviacao, @DescricaoCargo,@StatusCargo)";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AlterarComParametro()
        {
            try
            {
                SqlParameter[] listaComParametros = {new SqlParameter("@CodigoCargo",SqlDbType.Int) {Value = _CodigoCargo },
                   new SqlParameter("@NomeCargo",SqlDbType.VarChar) {Value = _NomeCargo },
                   new SqlParameter("@Abreviacao",SqlDbType.VarChar) {Value = _Abreviacao },
                   new SqlParameter("@DescricaoCargo",SqlDbType.VarChar) {Value = _DescricaoCargo },
                };

                instrucaoSql = "UPDATE tbCargo SET NomeCargo=@NomeCargo, Abreviacao=@Abreviacao,DescricaoCargo=@DescricaoCargo WHERE CodigoCargo=@CodigoCargo";
                c.ExecutarComandoParametro(instrucaoSql, listaComParametros);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Ativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbCargo SET StatusCargo=1   WHERE CodigoCargo=" + _CodigoCargo;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Desativar()
        {
            try
            {
                instrucaoSql = "UPDATE tbCargo SET StatusCargo=0   WHERE CodigoCargo=" + _CodigoCargo;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Excluir()
        {
            try
            {
                instrucaoSql = "DELETE FROM tbCargo  WHERE CodigoCargo=" + _CodigoCargo;
                c.ExecutarComando(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public SqlDataReader Consultar()
        {
            try
            {
                instrucaoSql = "SELECT * FROM tbCargo  WHERE CodigoCargo=" + _CodigoCargo;
                return c.RetornarDataReader(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       

        public DataSet Listar(string parteNome, byte tipostatus)
        {
            try
            {
                instrucaoSql = "SELECT * FROM tbCargo";
                if (parteNome.Length != 0)
                {
                    instrucaoSql = instrucaoSql + " WHERE NomeCargo LIKE '%" + parteNome + "%'"; //avisado sobre comportamento
                }
                return c.RetornarDataSet(instrucaoSql);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarAtivos()
        {
            try
            {
                instrucaoSql = "SELECT CodigoCargo, NomeCargo, StatusCargo FROM tbCargo WHERE StatusCargo=1";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet ListarInativos()
        {
            try
            {
                instrucaoSql = "SELECT CodigoCargo, NomeCargo FROM tbCargo WHERE StatusCargo=0";
                return c.RetornarDataSet(instrucaoSql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       



    }
}
