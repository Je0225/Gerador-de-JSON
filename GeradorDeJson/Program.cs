// See https://aka.ms/new-console-template for more information

using GeradorDeJson;

Json Json = new Json();

ObjectModel periodoApuracao = Json.AddObject("PeriodoApuracao");
periodoApuracao.AdicionaAtributo("MesApuracao", 11);
periodoApuracao.AdicionaAtributo("AnoApuracao", 2024);

ObjectModel dadosIniciais = Json.AddObject("DadosIniciais");
dadosIniciais.AdicionaAtributo("SemMovimento", false);
dadosIniciais.AdicionaAtributo("QualificacaoPj", 1);
dadosIniciais.AdicionaAtributo("TributacaoLucro", 3);

ObjectModel responsavelApuracao = dadosIniciais.AdicionaObjeto("ResponsavelApuracao");
responsavelApuracao.AdicionaAtributo("CpfResponsavel", "111.111.111-28");

ObjectModel telResponsavel = responsavelApuracao.AdicionaObjeto("TelResponsavel");
telResponsavel.AdicionaAtributo("Ddd", 45);
telResponsavel.AdicionaAtributo("NumTelefone", "99999-1111");

responsavelApuracao.AdicionaAtributo("EmailResponsavel", "email@empresa.com.br");
responsavelApuracao.AdicionaObjeto("RegistroCrc").AdicionaAtributo("UfRegistro", "PR");

ObjectModel debitos = Json.AddObject("Debitos");
debitos.AdicionaAtributo("BalancoLucroReal", false);

Console.WriteLine(Json.AsString());
