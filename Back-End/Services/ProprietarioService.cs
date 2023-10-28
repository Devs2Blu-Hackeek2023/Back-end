using Back_End.Data;
using Back_End.DTOs;
using Back_End.Model;
using Back_End.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly DataContext _data;

        public ProprietarioService(DataContext data)
        {
            _data = data;
        }

        public async Task CreateProprietario(ProprietarioDTO request)
        {
                ProprietarioModel prop = new ProprietarioModel();
                prop.CNH = request.CNH;
                prop.CPF = request.CPF;
                prop.NomeCompleto = request.NomeCompleto;
                prop.UsuarioId = request.UsuarioId;
                if(!(await _data.Proprietarios.FirstOrDefaultAsync(i => i.UsuarioId == request.UsuarioId) is null)){
                throw new Exception("Esse proprietário já possui uma conta.");
            }
                prop.Usuario = await _data.Usuarios.FirstOrDefaultAsync(i => i.Id == request.UsuarioId) ?? throw new Exception("Usuário não existe");

                
                await _data.AddAsync(prop);
                await _data.SaveChangesAsync();
            
        }

        public async Task DeleteProprietario(int Id)
        {
            var request = await _data.Proprietarios.FindAsync(Id) ?? throw new Exception("Proprietário não encontrado"); 

            _data.Proprietarios.Remove(request);

            await _data.SaveChangesAsync();

        }

        public async Task<List<ProprietarioModel>> GetAllProprietarios()
        {
            var proprietarios = await _data.Proprietarios.ToListAsync() ?? throw new Exception("Nenhum funcionário encontrado"); 
            return proprietarios;
        }

        public async Task<ProprietarioModel> GetProprietarioById(int Id)
        {
            var proprietario = await _data.Proprietarios.FindAsync(Id);
            if (proprietario is null) throw new Exception("Proprietário não encontrado");

            else return proprietario;
        }

        public async Task<List<VeiculoModel>> GetVeiculosByProprietario(int Id)
        {
            var veiculos = await _data.Veiculos.Where(prop => prop.ProprietarioId == Id).ToListAsync();
            if (veiculos is null) throw new Exception("Nenhum veículo encontrado");

            else return veiculos;

        }

        public async Task UpdateProprietario(int id, ProprietarioModel request)
        {
            var prop = await _data.Proprietarios.FindAsync(id);
            if (prop.Id != request.Id) throw new Exception("Id não encontrado no banco");
            else
            {
                prop.Id = request.Id;
                if(request.NomeCompleto != null && request.NomeCompleto != "string") prop.NomeCompleto = request.NomeCompleto;
            }
            await _data.SaveChangesAsync();


        }
    }
}
