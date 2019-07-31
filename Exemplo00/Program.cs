using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo00
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaContext contexto = new SistemaContext();

            #region inserir
            Animal animal2 = new Animal();
            animal2.Nome = "TRex";
            animal2.Extinto = true;

            contexto.Animais.Add(animal2);
            contexto.SaveChanges();
            Console
                .WriteLine("Registro salvo com sucesso");
            #endregion inserir

            #region apagar
            //Animal animalApagar = contexto
            //    .Animais.Where(x => x.Nome == "Porco aranha").First();
            //contexto.Animais.Remove(animalApagar);
            //contexto.SaveChanges();
            #endregion apagar

            #region alterar
            //var cachorro = contexto
            //    .Animais
            //    .Where()
            //    .First(x => x.Id == 4);

            //cachorro.Nome = "Cachorro";
            //contexto.SaveChanges();
            #endregion alterar

            #region listar
            List<Animal> animais = contexto
                .Animais
                //.Where(
                //    x => x.Extinto == false && 
                //    x.Nome.Contains("a")
                //)
                .OrderBy(x => x.Nome)
                .ToList();
            foreach (Animal animal in animais)
            {
                Console.WriteLine($"{animal.Id} - {animal.Nome} - {animal.Extinto} - {animal.Peso}");
            }
            #endregion listar

            #region InserirRelacionado
            Habilidade habilidade = new Habilidade();
            habilidade.IdAnimal = 1;
            habilidade.Nome = "Invisibilidade";

            contexto.Habilidades.Add(habilidade);
            contexto.SaveChanges();
            #endregion InserirRelacionado

            var habilidades = contexto.Habilidades
                .Include("Animal")
                .ToList();

            foreach(Habilidade habilidadeAux in habilidades)
            {
                Console.WriteLine(
                    habilidadeAux.Animal.Nome + " - " +
                    habilidadeAux.Nome);
            }



        }
    }
}
