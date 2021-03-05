using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace BlzorEmpleados.Data
{
    public class EstatusController
    {
        HttpClient Http;
        public string UrlEstatus = "/api/Estatus";
        //EstatusResponse EstatusR = new EstatusResponse();

        public async Task<bool> Guardar(Estatus estatus)
        {
            
            try
            {
                EstatusResponse ER = new EstatusResponse();
                if (estatus.EstatusId != 0)
                {
                    ER=  await Insertar(estatus);
                }
                else
                {
                    ER= await Modificar(estatus);
                }

                var paso = ER.Exito > 0;
            }
            catch (Exception)
            {

                
            }

            return paso;
        }

        public async Task<EstatusResponse> Insertar(Estatus estatus)
        {
            EstatusResponse EstatusR = new EstatusResponse();
            var response = await Http.PostAsJsonAsync<Estatus>(UrlEstatus, estatus);
            EstatusR = response.Content.ReadFromJsonAsync<EstatusResponse>().Result;

            return EstatusR;
        }

        public async Task<EstatusResponse> Modificar(Estatus estatus)
        {
            EstatusResponse EstatusR = new EstatusResponse();
            var response = await Http.PutAsJsonAsync<Estatus>(UrlEstatus, estatus);
            EstatusR = response.Content.ReadFromJsonAsync<EstatusResponse>().Result;

            return EstatusR;
        }

        public async Task<Estatus> Buscar(int EstatusId)
        {
            
            var response = await Http.GetFromJsonAsync<EstatusResponse>(UrlEstatus + "/" + Convert.ToInt32(EstatusId));
            var estatus = response.EstatusRespuesta;

            return estatus;
        }

        public async Task<EstatusResponse> Eliminar(int EstatusId)
        {

            var response = await Http.DeleteAsync(UrlEstatus + "/" + EstatusId);
            var EstatusR = response.Content.ReadFromJsonAsync<EstatusResponse>().Result;

            return EstatusR;

        }
    }
}
