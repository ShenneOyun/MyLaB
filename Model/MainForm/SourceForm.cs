using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Model;

namespace MainForm
{
    public partial class SourceForm : Form
    {
        public SourceForm()
        {
            InitializeComponent();
#if !DEBUG
CreateRandomDataButton.Visible = false;
#endif
        }
        public ISource Sourse
        {
            get
            {
                if (comboBox1.SelectedIndex==0)
                {
                    var book = new Book();
                    book.Author = Convert.ToString(textBoxAuthor.Text);
                    book.Title = Convert.ToString(textBoxTitle.Text);
                    book.Town = Convert.ToString(textBoxTown.Text);
                    book.Nomination = Convert.ToString(textBoxNomination.Text);
                    book.Coathor = Convert.ToString(textBoxCoathor.Text);
                    book.Reissue = Convert.ToString(textBoxReissue.Text);
                    book.PublishingHouse = Convert.ToString(textBoxPublishingHouse.Text);
                    book.Year = Convert.ToInt32(textBoxYear.Text);
                    book.Pages = Convert.ToInt32(textBoxPages.Text);
                    return book;
                }
                else if (comboBox1.SelectedIndex==1)
                {
                    var dissertation = new Dissertation();
                    dissertation.Author = Convert.ToString(textBoxAuthor.Text);
                    dissertation.Title = Convert.ToString(textBoxTitle.Text);
                    dissertation.Town = Convert.ToString(textBoxTown.Text);
                    dissertation.ScienceDegree = Convert.ToString(textBoxScienceDegree.Text);
                    dissertation.SpecialityCode = Convert.ToInt32(textBoxSpecialityCode.Text);
                    //dissertation.DataOfProtection = Convert.ToDateTime(dateTimePicker1.Date);
                    //dissertation.DataOfApproval = Convert.ToDateTime(dateTimePicker2);
                    dissertation.Year = Convert.ToInt32(textBoxYear.Text);
                    dissertation.Pages = Convert.ToInt32(textBoxPages.Text);
                    return dissertation;
                }
                else
                {
                    var electronicResource = new ElectronicResource();
                    electronicResource.Author = Convert.ToString(textBoxAuthor);
                    electronicResource.Title = Convert.ToString(textBoxTitle.Text);
                    electronicResource.URL = Convert.ToString(textBoxURL.Text);
                    return electronicResource;
                }
            }
            set
            {
                if (value is Book)
                {
                    var book = (Book) value;
                    comboBox1.SelectedIndex = 0;
                    textBoxAuthor.Text = book.Author;
                    textBoxTitle.Text = book.Title;
                    textBoxTown.Text = book.Town;
                    textBoxNomination.Text = book.Nomination;
                    textBoxReissue.Text = book.Reissue;
                    textBoxCoathor.Text = book.Coathor;
                    textBoxPublishingHouse.Text = book.PublishingHouse;
                    textBoxYear.Text = book.Year.ToString();
                    textBoxPages.Text = book.Year.ToString();
                }
                else if (value is Dissertation)
                {
                    var dissertation = (Dissertation)value;
                    comboBox1.SelectedIndex = 1;
                    textBoxAuthor.Text = dissertation.Author;
                    textBoxTitle.Text = dissertation.Title;
                    textBoxTown.Text = dissertation.Town;
                    textBoxScienceDegree.Text = dissertation.ScienceDegree;
                    textBoxSpecialityCode.Text = dissertation.SpecialityCode.ToString();
                    textBoxYear.Text = dissertation.Year.ToString();
                    textBoxPages.Text = dissertation.Year.ToString();
                    
                }
                else
                {
                    var electronicResource = (ElectronicResource)value;
                    comboBox1.SelectedIndex = 2;
                    textBoxAuthor.Text = electronicResource.Author;
                    textBoxTitle.Text = electronicResource.Title;
                    textBoxURL.Text = electronicResource.URL;
                }
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                labelAuthor.Visible = true;
                labelCoathor.Visible = true;
                labelNomination.Visible = true;
                labelPublishingHouse.Visible = true;
                labelReissue.Visible = true;
                labelTitle.Visible = true;
                labelTown.Visible = true;
                labelYear.Visible = true;
                labelPages.Visible = true;
                labelScienceDegree.Visible = false;
                labelSpecialityCode.Visible = false;
                labelURL.Visible = false;
                labelDateOfApproval.Visible = false;
                labelDateOfProtection.Visible = false;

                textBoxAuthor.Visible = true;
                textBoxTitle.Visible = true;
                textBoxCoathor.Visible = true;
                textBoxTown.Visible = true;
                textBoxNomination.Visible = true;
                textBoxPublishingHouse.Visible = true;
                textBoxReissue.Visible = true;
                textBoxPages.Visible = true;
                textBoxYear.Visible = true;
                textBoxURL.Visible = false;
                textBoxScienceDegree.Visible = false;
                textBoxSpecialityCode.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                labelAuthor.Visible = true;
                labelCoathor.Visible = false;
                labelNomination.Visible = false;
                labelPublishingHouse.Visible = false;
                labelReissue.Visible = false;
                labelTitle.Visible = true;
                labelTown.Visible = true;
                labelYear.Visible = true;
                labelPages.Visible = true;
                labelScienceDegree.Visible = true;
                labelSpecialityCode.Visible = true;
                labelURL.Visible = false;
                labelDateOfApproval.Visible = true;
                labelDateOfProtection.Visible = true;

                textBoxAuthor.Visible = true;
                textBoxTitle.Visible = true;
                textBoxCoathor.Visible = false;
                textBoxTown.Visible = true;
                textBoxNomination.Visible = false;
                textBoxPublishingHouse.Visible = false;
                textBoxReissue.Visible = false;
                textBoxPages.Visible = true;
                textBoxYear.Visible = true;
                textBoxURL.Visible = false;
                textBoxScienceDegree.Visible = true;
                textBoxSpecialityCode.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
            }
            else
            {
                labelAuthor.Visible = true;
                labelCoathor.Visible = false;
                labelNomination.Visible = false;
                labelPublishingHouse.Visible = false;
                labelReissue.Visible = false;
                labelTitle.Visible = true;
                labelTown.Visible = false;
                labelYear.Visible = false;
                labelPages.Visible = false;
                labelScienceDegree.Visible = false;
                labelSpecialityCode.Visible = false;
                labelURL.Visible = true;
                labelDateOfApproval.Visible = false;
                labelDateOfProtection.Visible = false;

                textBoxAuthor.Visible = true;
                textBoxTitle.Visible = true;
                textBoxCoathor.Visible = false;
                textBoxTown.Visible = false;
                textBoxNomination.Visible = false;
                textBoxPublishingHouse.Visible = false;
                textBoxReissue.Visible = false;
                textBoxPages.Visible = false;
                textBoxYear.Visible = false;
                textBoxURL.Visible = true;
                textBoxScienceDegree.Visible = false;
                textBoxSpecialityCode.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;            
            }
        }

        //рандомное заполнение
        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Random random = new Random();
                textBoxPages.Text = random.Next(50, 800).ToString();
                textBoxYear.Text = random.Next(1970, 2017).ToString();                
                string[] author =
                {
                    "Рей Брэдбери",
                    "Эрих Мария Ремарк",
                    "Чак Паланик",
                    "Достоевский Ф.М",
                    "Пушкин А.С",
                    "Джордж Мартин",
                    "Стивен Кинг",
                    "Джоан Роулинг",
                    "Маргарет Митчел",
                    "Булгаков М.А",
                    "Гоголь Н.В",
                    "Грибоедов А.С",
                    "Артур Конан Дойл",
                    "Магазинников Л.И"
                };
                textBoxAuthor.Text = (author[random.Next(author.Length)]);
                string[] title =
                {
                    "451 по Фаренгейту",
                    "Три товарища",
                    "Бойцовский клуб",
                    "Преступление и наказание",
                    "Евгений Онегин",
                    "Игра престолов",
                    "Зеленая миля",
                    "Гарри Поттер и философский камень",
                    "Унесенные ветром",
                    "Мастер и Маргарита",
                    "Мертвые души",
                    "Горе от ума",
                    "Приключения Шерлока Холмса",
                    "Высшая математика"
                };
                textBoxTitle.Text = (title[random.Next(title.Length)]);
                string[] coathor =
                {
                    "Сьюзен Колинс",
                    "Харуки Муракаму",
                    "Стивен Хокинг",
                    "Эльчин Сафарли",
                    "Владимир Набоков",
                    "Джон Грин",
                    "Виктор Франкл",
                    "Артур Хейли",
                    "Дэн Браун",
                    "Дэвид Митчелл",
                };
                textBoxCoathor.Text = (coathor[random.Next(coathor.Length)]);
                string[] town =
                {
                    "Нью Йорк",
                    "Москва",
                    "Новосибирск",
                    "Санкт-Петербург",
                    "Томск",
                    "Кызыл",
                    "Саратов",
                    "Дубай",
                    "Мадрид",
                    "Лас-Вегас"
                };
                textBoxTown.Text = (town[random.Next(town.Length)]);
                string[] nomination =
                {
                    "роман",
                    "пьеса",
                    "фантастика",
                    "фантастический боевик",
                    "поэма",
                    "мемуары",
                    "учебная литература",
                    "детектив",
                    "автобиографическая повесть",
                    "драма"
                };
                textBoxNomination.Text = (nomination[random.Next(nomination.Length)]);
                string[] publishing =
                {
                    "Альфа-книга",
                    "Эксмо",
                    "Аст",
                    "Центрополиграф",
                    "Олма-медиа групп",
                    "Рипол-классик",
                    "Вече",
                    "Просвещение",
                    "Вильямс",
                    "Астрель-СПб"
                };
                textBoxPublishingHouse.Text = (publishing[random.Next(publishing.Length)]);
                string[] reissue =
                {
                    "2-е изд., перераб. и доп",
                    "Изд.2-е, испр. доп",
                    "3-е зд., перераб и доп",
                    "4-е изд., стереотип",
                };
                textBoxReissue.Text = (reissue[random.Next(reissue.Length)]);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Random random = new Random();
                textBoxPages.Text = random.Next(50, 800).ToString();
                textBoxYear.Text = random.Next(1970, 2017).ToString();
                textBoxSpecialityCode.Text = random.Next(100000, 1000000).ToString();
                string[] author =
                {
                    "Оюн. Ш.Х",
                    "Конради Ю.Н",
                    "Крахмалева А.О",
                    "Видершпан А.А",
                    "Очерков И.Н",
                    "Мамонов В.П",
                    "Зайцев П.С",
                    "Огарко Ю.А",
                    "Проскоков М.В",
                    "Файль. Т.Т",
                    "Иванов. А.И",
                    "Шестеров. И.И"
                };
                textBoxAuthor.Text = (author[random.Next(author.Length)]);
                string[] scienceDegree = 
                {
                    "канд. техн.наук",
                    "канд. техн.наук",
                    "канд. мед.наук",
                    "канд. экон.наук"
                };
                textBoxScienceDegree.Text = (scienceDegree[random.Next(scienceDegree.Length)]);
            
            string[] title =
                {
                    "Изучение клеточной реактивности при ожоговой болезни",
                    "Становление новой экономики в России",
                    "Метод идентификации сложного объекта управления по модели дисперсии агрегированной переменной",
                    "Архитектура программных агентов для проверки соответствия распределенных документов",
                    "Скоростной механический сканатор мобильного наземного транспортного робота",
                    "Исследование устойчивости плоских пластинчатых систем",
                    "Частота пробоотсекания при апробировании пульп на флотационных фабриках",
                    "Исследование двух моделей многомоторных бомбардировщиков",
                    "Разработка и применение методов и средств контроля состояния материалов на АЭС",
                    "Основы теории и создание герметичных машин и аппаратов с магнитными муфтами"
                };
                textBoxTitle.Text = (title[random.Next(title.Length)]);
                string[] town =
                {
                    "Омск",
                    "Москва",
                    "Новосибирск",
                    "Санкт-Петербург",
                    "Томск",
                    "Кызыл",
                    "Саратов",
                    "Волгоград",
                    "Хабаровск",
                    "Мурманск"
                };
                textBoxTown.Text = (town[random.Next(town.Length)]);
                //dateTimePicker1 = random.Next(Tim).ToString();
                //dateTimePicker2=random.Next(DateTimeConverter);
            }
            else
            {
                Random random=new Random();
                string[] url =
                {
                    "http://soccer365.ru",
                    "https://www.leon.ru/",
                    "https://vk.com/",
                    "http://new.kcup.tusur.ru/",
                    "https://timetable.tusur.ru/",
                    "http://www.nike.com/ru/ru_ru/",
                    "https://git-scm.com/",
                    "http://htmlbook.ru/"
                };
                textBoxURL.Text = (url[random.Next(url.Length)]);
                string[] author =
                {
                    "Корнющенко Ю.В",
                    "Хованский. Ю.П",
                    "Субботина В",
                    "Райдос Виктория"
                };
                textBoxAuthor.Text = (author[random.Next(author.Length)]);
                string[] title =
                {
                    "Букмекерская контора Леон",
                    "GIT",
                    "Soccer",
                    "NIKE",
                    "КСУП",
                    "ТУСУР"
                };
                textBoxTitle.Text = (title[random.Next(title.Length)]);

            }

        }

        //кнопка отмены
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.CancelButton = buttonCancel;
        }
    }
}
