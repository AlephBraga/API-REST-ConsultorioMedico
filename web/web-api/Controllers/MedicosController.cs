using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using web_api.Configurations;

namespace web_api.Controllers
{
    //[EnableCors(origins:"*", headers:"*", methods:"*")]
    public class MedicosController : ApiController
    {
        private Repositories.Database.SQLServer.ADO.Medico repository;
        public MedicosController()
        {
            repository = new Repositories.Database.SQLServer.ADO.Medico(SQLServer.GetConnectionString());
        }
        // GET: api/Medicos
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(repository.get());
            }
            catch (Exception ex)
            {
                Logger.Log.Write(ex, Log.getFullPath());
                return InternalServerError();
            }
        }


        // GET: api/Medicos/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Models.Medico medico = repository.getById(id);

                if (medico.Codigo == 0)
                    return NotFound();

                return Ok(medico);
            }
            catch (Exception ex)
            {
                Logger.Log.Write(ex, Log.getFullPath());
                return InternalServerError();
            }
        }

        // POST: api/Medicos
        public IHttpActionResult Post(Models.Medico medico)
        {
            try
            {
                if(!ModelState.IsValid)
                        return BadRequest(ModelState);

                repository.add(medico);

                return Ok(medico);
            }
            catch (Exception ex)
            {
                Logger.Log.Write(ex, Log.getFullPath());
                return InternalServerError();
            }
        }

        // PUT: api/Medicos/5
        public IHttpActionResult Put(int id, Models.Medico medico)
        {
            try
            {
                if (id != medico.Codigo)
                    ModelState.AddModelError("Codigo", "Codigo do paciente difere do código requisitado");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int linhasAfetadas = repository.update(id, medico);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok(medico);

            }
            catch (Exception ex)
            {
                Logger.Log.Write(ex, Log.getFullPath());
                return InternalServerError();
            }
        }

        // DELETE: api/Medicos/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int linhasAfetadas = repository.delete(id);

                if (linhasAfetadas == 0)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(Log.getFullPath(), true))
                {
                    sw.WriteLine($"\n------\nData:{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} \n Mensagem:{ex.Message} \n StackTrace:{ex.StackTrace} \n InnerException:{ex.InnerException} \n Tipo do erro: {ex.GetType()} \n Source: {ex.Source} \n TargetSite: {ex.TargetSite}");
                }

                return InternalServerError();
            }
        }

    }
}
