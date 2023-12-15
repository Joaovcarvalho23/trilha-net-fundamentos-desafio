using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            Regex padraoPlaca = new Regex("^[A-Z]{3}-[0-9]{4}"); //expressão que verifica se o padrão da placa é LETRALETRALETRA-NUMERONUMERONUMERONUMERO

            if(padraoPlaca.IsMatch(placa))
            {
                var possuiPlaca = veiculos.Contains(placa); //variável para verificar se o veículo com a placa informada já existe no estacionamento

                if(possuiPlaca) Console.WriteLine($"O veículo de placa {placa} já existe no estacionamento!"); //se existir | possuiPlaca = true
                else
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo de placa {placa} foi adicionado no estacionamento com sucesso! :)");
                } // se não existir, adicione o veículo no estacionamento!
            }
            else
            {
                Console.WriteLine("Formato de placa inválido. A placa deve seguir o padrão LETRALETRALETRA-NUMERONUMERONUMERONUMERO");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if(int.TryParse(Console.ReadLine(), out int horas)){
                    decimal valorTotal = precoInicial + (precoPorHora * horas);

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Por favor, informe um valor válido para as horas.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
