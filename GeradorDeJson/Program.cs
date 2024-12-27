// See https://aka.ms/new-console-template for more information

using GeradorDeJson;

Json Json = new Json();
Json.AddAtributo("nome", "Jenifer");
Json.AddAtributo("idade", 22);
Json.AddAtributo("nascimento", new DateTime(2002, 2, 25));

ObjectModel giovano = Json.AddObject("Pessoa");
giovano.AdicionaAtributo("Nome", "Giovano");
giovano.AdicionaAtributo("função", "programador");
ObjectModel plantaDoGiovavo = giovano.AdicionaObjeto("planta", "suculenta");
plantaDoGiovavo.AdicionaAtributo("corDoVaso", "branco");
Console.WriteLine(Json.ToString());
