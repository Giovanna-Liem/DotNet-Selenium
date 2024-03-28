using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Primeiro_teste_DotNet
{
    public class Tests { 

        //public required IWebDriver Driver;

        [Test]
        public void Test1()
        {
            //1.Escreva um script de automação usando Selenium em.NET para verificar se a página inicial exibe pelo menos 5 produtos em destaque.
            // Configurar o navegador que vamos utilizar
            IWebDriver driver = new ChromeDriver();

            // Acessar a URL
            driver.Navigate().GoToUrl("https://www.amazon.com.br/");

            // Maximizar a janela
            driver.Manage().Window.Maximize();

            // Esperar para que o elemento seja carregado
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Encontrar Categoria Produtos em destaque
            IWebElement encontrarTitulo = driver.FindElement(By.XPath("//span[.='Confira Produtos de Mulheres Empreendedoras']"));
            string text = encontrarTitulo.Text;
            Console.WriteLine("-------------------------" + text + "-------------------------");

            // Contar Produtos em destaque
            var elementos = driver.FindElements(By.ClassName("a-list-item"));
            Console.WriteLine("Quantidade de produtos:" + elementos.Count());

            if (elementos.Count > 5)
            {
                Console.WriteLine("O número é maior que 5.");
            }
            else
            {
                Console.WriteLine("O número não é maior que 5.");
            }



            //2. Escreva um teste para garantir que o usuário possa adicionar um produto ao carrinho de compras a partir da página de detalhes do produto.
            IWebElement carrossel = driver.FindElement(By.Id("desktop-banner"));
            // Clicar no produto
            carrossel.Click();

            //2. Escreva um teste para garantir que o usuário possa adicionar um produto ao carrinho de compras a partir da página de detalhes do produto.
            IWebElement adicionarCarrinho = driver.FindElement(By.Id("add-to-cart-button"));
            // Clicar no produto
            adicionarCarrinho.Click();

            // Esperar para que a página seja carregada
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            // Verificar se o produto foi adicionado ao carriho
    
            IWebElement confirmacaoCompra = driver.FindElement(By.XPath("//h1[@class='a-size-medium-plus a-color-base sw-atc-text a-text-bold']"));

            // Ir para o carrinho
            IWebElement irAoCarrinho = driver.FindElement(By.XPath("//span[@id='sw-gtc']//a[contains(.,'Ir para o carrinho')]"));


            // Fechar o navegador
            //driver.Quit();
        }
    }

}