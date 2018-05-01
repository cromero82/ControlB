using Model;
using Model.Auxiliar;
using Model.BL;
using Model.BL.Tipos;
using Model.General;
using Persistence;
using Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL
{
    public class TlistasBL
    {
        // Contexto de base de datos (EF)
        private bdControlC db = new bdControlC();

        /// <summary>
        /// Obtiene lista de tipos de caracteristicas 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTcaracteristicas()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tcaracters.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de especialidades del nivel academico
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTespecialidades()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tespecialidades.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Inserta lista de departamentos
        /// </summary>
        /// <param name="model"> Modelo de datos abiertos con listado de departamentos</param>
        /// <returns> Resultado de la transacción</returns>
        public Jresult InsDepartamentos(DatosAbiertosImport model)
        {
            var jresult = new Jresult();
            try
            {                                
                foreach(DatosAbiertosDepartamentos item in model.DepartamentosList)
                {
                    var itemModel = new Tdepartamentos();                    
                    itemModel.Cod = item.iddepto;
                    itemModel.Nombre = item.nomdepto.ToString().TrimStart(' ');
                    itemModel.Latitud = item.deptolatitud;
                    itemModel.Longitud = item.deptolongitud;
                    db.Tdepartamentos.Add(itemModel);
                }
                
                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Departamentos registrados satisfactoriamente";

            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de departamentos 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListDepartamentos()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tdepartamentos.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Inserta lista de departamentos
        /// </summary>
        /// <param name="model"> Modelo de datos abiertos con listado de departamentos</param>
        /// <returns> Resultado de la transacción</returns>
        public Jresult InsListaMunicipios(DatosAbiertosImport model)
        {
            var jresult = new Jresult();
            var idDep = 0;
            try
            {
                foreach (DatosAbiertosMunicipios item in model.MunicipiosList)
                {
                    // consulta el id del departamento
                    idDep = db.Tdepartamentos.Where(x => x.Cod == item.cod_depto).FirstOrDefault().Id;

                    // prepara el model y registra
                    var itemModel = new Tmunicipios();
                    itemModel.DepartamentoId = idDep; //int.Parse(item.cod_depto);
                    itemModel.Cod = item.cod_mpio;                    
                    itemModel.Nombre = item.nom_mpio;
                    db.Tmunicipios.Add(itemModel);
                }

                db.SaveChanges();
                jresult.Success = true;;
                jresult.Message = "Municipios registrados satisfactoriamente";

            }
            catch (Exception ex)
            {
                //jresult.SetError(ex);
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de municipios 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListMunicipios()
        {
            var jresult = new Jresult();
            try
            {
                // Model intermedio
                BindGateway dataResult = new BindGateway();

                // Consulta básica
                var listaDatos = (
                        from d in db.Tdepartamentos
                        from m in db.Tmunicipios.Where(x => x.DepartamentoId == d.Id)
                        select new
                        {
                            Id = m.Id,
                            Nombre = m.Nombre,                            
                            Cod = m.Cod,
                            NombreDepartamento = d.Nombre
                        }
                    );

                // asigna a model de bindeo
                dataResult.Data = listaDatos.ToList();
                dataResult.Count = listaDatos.ToList().Count();

                // asigna model de bindeo a Jresult
                jresult.Data = dataResult;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de paises 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListPaises()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tpaises.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de metodologías 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListMetodologias()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tmetodologias.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de documentos 
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTiposDocumentos()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tdocumentos.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de estratos sociales
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListEstratosSociales()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Testratos.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de SISBEN
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListSisben()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tsisbens.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de victimas del conflicto
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTiposVictimasConfl()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.TpVictimaConflictoes.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de discapacidades de personas
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTiposDiscapacidades()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tdiscapacidades.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de discapacidades de personas
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTiposCapacidadesExcep()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.TcapExcepcionales.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }

        /// <summary>
        /// Obtiene lista de tipos de grupos etnicos
        /// </summary>        
        /// <returns> lista de datos</returns>
        public Jresult GetListTiposEtnias()
        {
            var jresult = new Jresult();
            try
            {
                var listaDatos = db.Tetnias.Where(x => x.Estado == 1).ToList();
                jresult.Data = listaDatos;
                jresult.Success = true;;
            }
            catch (Exception ex)
            {
                jresult.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return jresult;
        }
    }
}
