using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day12_1_미연시
{
    interface IHero
    {
        string Name { get; }
        int Affection { get; set; }
        int Age { get; }
        void PrintStory();
        void TalkWorkSite(Game game);
        void TalkPcCafe(Game game, Me me);
        void Talkkaraoke(Game game, Me me);
        void TalkDogCafe(Game game, Me me);


    }
    public class Boy1 : IHero
    {
        public string Name { get; } = "boy1";
        int affection = 0;
        public int Age { get; } = 23;

        public int Affection
        {
            get { return affection; }
            set { affection = value; if (affection < 0) affection = 0; }
        }

        public void PrintStory()
        {
            Console.WriteLine("============남주 1============");
            Console.WriteLine($"이름은 {Name}, 나이는 {Age}. 유치원 때부터 친하게 지내고 있는 소꿉친구이다.");
            Console.WriteLine("카페에서 알바중이며, 강아지 뽀삐를 키우는 중이다. 악세사리를 좋아한다.");
            Console.WriteLine("");
            Thread.Sleep(1500);
        }
        public void TalkWorkSite(Game game)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 연락도 없이 무슨 일이야?", ": 바빠. 얼른 주문해" };
            string[] highaffection = new string[] { ": 연락 하고 오지! 잠깐만 앉아있어. 늘 먹던 걸로 만들어줄게!", ": 곧 퇴근이니까 같이 저녁 먹자!" };
            game.Hour += 1;


            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 내가 찾아온 게 크게 반갑진 않은 모양이다..");
                Affection += 2;
                Thread.Sleep(2000);
            }

            else if (Affection > 60)
            {
                game.Hour += 1;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Affection += 10;
            }

        }
        public void TalkPcCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": pc방? 니가 나보다 게임 잘해서 싫어 ㅋㅋ", ": 나 이따 약속있어 담에 ㄱㄱ" };
            string[] highaffection = new string[] { ": 나 오늘 골드 보내주는 거다", ": 문도 피구 ㄱㄱ" };


            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 나랑 게임하기 싫어하는 것 같다..");
                Affection -= 3;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 3;
                me.Money -= 10000;

                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}과 재밌는 시간을 보냈다!");
                Affection += 10;
                Thread.Sleep(2000);


            }
        }
        public void Talkkaraoke(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 너 진짜 노래방 좋아하긴 한다.", ": 난 이런 데 오면 뭘 불러야 할지 모르겠어." };
            string[] highaffection = new string[] { ": 너 예전보다 노래 잘하네? 연습했어?", ": 오랜만에 같이 노니까 좋다. 이런 건 가끔 와도 괜찮네." };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 노래 부르는 것을 별로 좋아하지 않는 것 같다..");
                Affection -= 4;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 2;
                me.Money -= 10000;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine("시간 가는 줄 모르고 불렀다!");
                Affection += 10;
                Thread.Sleep(2000);
            }
        }
        public void TalkDogCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 비염때문에 털 날리는 건 좀 힘들다.", ": 얘네 귀엽긴하다. 근데 넌 이런 데 자주 오냐?." };
            string[] highaffection = new string[] { ": 얘 봐, 너한테만 붙네. 사람 보는 눈 있네.", ": 너 얼굴에 털 묻었어. 가만히 있어봐." };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 애견카페가 그리 편한 것 같진 않다..");
                Affection -= 3;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                me.Money -= 20000;
                game.Hour += 2;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(1000);
                Console.WriteLine($"{Name}은 강아지 보다 나에게 더 집중한 것 같다..!");
                Affection += 8;
                Thread.Sleep(2000);
            }
        }

    }

    public class Boy2 : IHero
    {
        public string Name { get; } = "boy2";

        public int affection = 0;
        public int Age { get; } = 21;
        public int Affection
        {
            get { return affection; }
            set { if (affection < 0) affection = 0; }
        }


        public void PrintStory()
        {
            Console.WriteLine("============남주 2============");
            Console.WriteLine($"이름은 {Name}, 나이는 {Age}. 친구가 소개시켜 준 남자다. 가끔 같이 밥도 먹고 간간히 연락하는 사이다.");
            Console.WriteLine("편의점에서 알바 중이며, 가방엔 늘 키링이 주렁주렁 달려있다.");
            Console.WriteLine("");
            Thread.Sleep(1500);
        }
        public void TalkWorkSite(Game game)
        {

            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 손님 많아요. 얼른 계산 해줄게요.", ": 수다 떨다 걸리면 저 혼나요. 얼른 가요" };
            string[] highaffection = new string[] { ": 와 저 진짜 피곤했는데 누나 보니까 피곤이 싹 사라졌어요", ": 배 안 고파요? 제가 편의점 정식 만들어줄게요!" };
            game.Hour += 1;

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 내가 찾아와 곤란한 것 같다..");
                Affection -= 5;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 1;
                Console.WriteLine(Name + highaffection[a]);
                Affection += 10;
                Thread.Sleep(2000);

            }
        }
        public void TalkPcCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": pc방이요? 저 알바 가야하는데...", ": 제가 오늘 도서관에 가야해서요." };
            string[] highaffection = new string[] { ": 같이 카트라이더 할까요?!", ": 같이 크레이지 아케이드 해요!!" };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 오늘 바쁜가보다..");
                Affection -= 3;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 3;
                me.Money -= 10000;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine("시간 가는 줄 모르고 놀았다!");
                Affection += 10;
                Thread.Sleep(2000);

            }
        }
        public void Talkkaraoke(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 누나 노래 못 하면 놀릴 거예요.", ": 한 곡만 하고 가요. 제가 먼저 부를게요." };
            string[] highaffection = new string[] { ": 같이 부를래요? 이런 건 둘이 불러야 제맛이죠.", ": 목소리랑 잘 어울릴 것 같은데, 이거 불러줘요!" };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 노래방을 좋아하나보다!");
                Affection += 5;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 2;
                me.Money -= 10000;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine("둘은 시간 가는 줄 모르고 불렀다!");
                Affection += 15;
                Thread.Sleep(2000);
            }
        }
        public void TalkDogCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 얘 너무 활발하네요. 나 이런 거 좀 무서운데…", ": 전 강아지 보단 고양이가 좋은 것 같아요." };
            string[] highaffection = new string[] { ": 강아지도 생각보단 귀엽네요.", ": 강아지도 제가 싫진 않은가봐요!!" };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 강아지를 별로 좋아하지 않는 것 같다...");
                Affection -= 5;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                me.Money -= 20000;
                game.Hour += 2;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"강아지에게 마음을 여는 {Name}의 모습이 귀여웠다!");
                Affection += 10;
                Thread.Sleep(2000);
            }
        }

    }

    public class Boy3 : IHero
    {
        public string Name { get; } = "boy3";
        public int affection = 0;
        public int Age { get; } = 25;
        public int Affection
        {
            get { return affection; }
            set { if (affection < 0) affection = 0; }
        }


        public void PrintStory()
        {
            Console.WriteLine("============남주 3============");
            Console.WriteLine($"남주3: 이름은 {Name}, 나이는 {Age}. 나보다 고학번이지만 함께 복학한 복학생이다. 같은 학년 유일한 친구.");
            Console.WriteLine("서점에서 알바중이고, 며칠 전 모자를 잃어버렸다고 한다.");
            Console.WriteLine("");
            Thread.Sleep(1500);
        }
        public void TalkWorkSite(Game game)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 오늘은 정리할 게 많아서 바빠. 얼른 가", ": 전공 서적은 저 쪽." };
            string[] highaffection = new string[] { ": 책 고르는 척하면서 나 보러 온 거지?", ": 서점 단골 손님 중에 제일 자주 보는 사람 같네." };
            game.Hour += 1;

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 내가 온 게 싫지만은 않은가보다!");
                Affection += 3;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 1;
                Console.WriteLine(Name + highaffection[a]);
                Affection += 10;
                Thread.Sleep(2000);
            }
        }
        public void TalkPcCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 나는 피시방에서 게임 잘 안 해서..", ": 너 공부 안 해?" };
            string[] highaffection = new string[] { ": 나 게임 좀 잘해. 각오해 ㅋㅋ", ": 그래 가자!" };

            if (Affection < 60)
            {
                Console.WriteLine(lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 가고 싶어하지 않는 것 같다...");
                Affection -= 3;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 3;
                me.Money -= 10000;
                Console.WriteLine(highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 게임을 좋아하는 것 같다!!");
                Affection += 16;
                Thread.Sleep(2000);
            }
        }
        public void Talkkaraoke(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 이런 데 잘 안 와서 어색하네.", ": 노래 부르는 건 아직 부끄럽고.. 듣는 건 괜찮아." };
            string[] highaffection = new string[] { ": 노래 잘 부르네. 너랑 오니까 있을만 하다.", ": 내 노래 듣고싶다니까 한 곡 할게." };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 어색해 했지만, 내 노래를 열심히 들어줬다!");
                Affection += 2;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                game.Hour += 2;
                me.Money -= 10000;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}이 노래 부르는 걸 처음 들었다!");
                Affection += 7;
                Thread.Sleep(2000);
            }
        }
        public void TalkDogCafe(Game game, Me me)
        {
            Random rand = new Random();
            int a = rand.Next(0, 2);

            string[] lowaffection = new string[] { ": 얘네랑 있으면 머리 식는다. 조용해서 좋아.", ": 손 대면 물 수도 있으니까 천천히 다가가." };
            string[] highaffection = new string[] { ": 얘가 너 옆에만 있네. 보통 사람한텐 안 그러는데.", ": 강아지들 때문인지 모르겠는데… 오늘 기분이 좀 좋다." };

            if (Affection < 60)
            {
                Console.WriteLine(Name + lowaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"{Name}은 강아지를 좋아하는 것 같다!");
                Affection += 4;
                Thread.Sleep(2000);
            }
            else if (Affection > 60)
            {
                me.Money -= 20000;
                game.Hour += 2;
                Console.WriteLine(Name + highaffection[a]);
                Thread.Sleep(2000);
                Console.WriteLine($"강아지 덕분에 {Name}과 가까워진 것 같다!");
                Affection += 18;
                Thread.Sleep(2000);
            }
        }

    }

    public class Me
    {
        public string Name { get; set; }
        public int Age { get; } = 23;
        int money = 10000;

        int hp = 200;
        int stress = 0;

        bool love = false;
        public int Money
        {
            get { return money; }
            set { money = value; if (money < 0) money = 0; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; if (hp < 0) hp = 0; }
        }
        public int Stress
        {
            get { return stress; }
            set { stress = value; if (stress < 0) hp = 0; }
        }

        public bool Love
        {
            get { return love; }
            set { love = value; }
        }

        public void PrintStory()
        {
            Console.WriteLine($"내 이름은 {Name}. {Age}살 복학생이다.");
            Thread.Sleep(1500);
        }
        public void PrintMyStat()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"나이: {Age}");
            Console.WriteLine($"돈: {Money}");
            Console.WriteLine($"체력: {HP}");
            Console.WriteLine($"피로도: {Stress}");
        }
        public void PrintStat()
        {
            Console.WriteLine($"소지 금액: {Money}");
            Console.WriteLine($"체력: {HP}");
            Console.WriteLine($"스트레스 지수: {Stress}");
        }
    }

    public class Game
    {
        int hour = 0;
        int day = 0;
        int teachingcount { get; set; } = 0;

        public int Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public int Day
        {
            get { return day; }
            set { day = value; if (hour >= 24) day++; }
        }

        public int SelectAction()
        {
            int action = int.Parse(Console.ReadLine());
            return action;
        }
        public void GoToWorkSite(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            if (me.Money == 0 || me.Money < 8000)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }
            Console.Write("누구의 일터로 갈까요? (1)boy1 (2)boy2 (3)boy3: ");
            int selectwhossite = int.Parse(Console.ReadLine());
            me.Money -= 8000;
            if (selectwhossite == 1)
            {
                boy1.TalkWorkSite(this);
                return;
            }
            else if (selectwhossite == 2)
            {
                boy2.TalkWorkSite(this);
                return;
            }
            else if (selectwhossite == 3)
            {
                boy3.TalkWorkSite(this);
                return;
            }
            else Console.WriteLine("잘못된 입력입니다.");
        }
        public void GoToPcCafe(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.Write("피시방을 누구와 갈까요? (1)boy1 (2)boy2 (3)boy3: ");
            int selectwhosPc = int.Parse(Console.ReadLine());
            if (me.Money == 0 || me.Money < 8000)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }
            me.Money -= 5000;
            if (selectwhosPc == 1)
            {
                boy1.TalkPcCafe(this, me);
                return;
            }
            else if (selectwhosPc == 2)
            {
                boy2.TalkPcCafe(this, me);
                return;
            }
            else if (selectwhosPc == 3)
            {
                boy3.TalkPcCafe(this, me);
                return;
            }
            else Console.WriteLine("잘못된 입력입니다.");
        }
        public void GoToKagaoke(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.Write("노래방을 누구와 갈까요? (1)boy1 (2)boy2 (3)boy3: ");
            int selectwhosPc = int.Parse(Console.ReadLine());
            if (me.Money == 0 || me.Money < 10000)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }
            me.Money -= 10000;
            if (selectwhosPc == 1)
            {
                boy1.Talkkaraoke(this, me);
            }
            else if (selectwhosPc == 2)
            {
                boy2.Talkkaraoke(this, me);
            }
            else if (selectwhosPc == 3)
            {
                boy3.Talkkaraoke(this, me);
            }
            else Console.WriteLine("잘못된 입력입니다.");
        }
        public void GoToDogCafe(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.Write("애견카페를 누구와 갈까요? (1)boy1 (2)boy2 (3)boy3: ");
            int selectwhosDog = int.Parse(Console.ReadLine());
            if (me.Money == 0 || me.Money < 30000)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }
            me.Money -= 30000;
            if (selectwhosDog == 1)
            {
                boy1.TalkDogCafe(this, me);
                return;
            }
            else if (selectwhosDog == 2)
            {
                boy2.TalkDogCafe(this, me);
                return;
            }
            else if (selectwhosDog == 3)
            {
                boy3.TalkDogCafe(this, me);
                return;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }
        }
        public void GoToShoppingCenter(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.Write("어떤 선물을 살까요? (1)과자 (2)팔찌 (3)모자 (4)키링: ");
            int selectpresent = int.Parse(Console.ReadLine());

            if (selectpresent == 1)
            {
                if (me.Money < 5000)
                {
                    Console.WriteLine("돈이 부족합니다..");
                    return;
                }
                me.Money -= 5000;
                Console.Write("과자를 누구에게 선물할까요? (1)boy1 (2)boy2 (3)boy3: ");
                int give = int.Parse(Console.ReadLine());
                Hour += 2;

                if (give == 1)
                {
                    Console.WriteLine(boy1.Name + ": 오 과자! 땡큐!");
                    boy1.Affection += 10;
                }
                else if (give == 2)
                {
                    Console.WriteLine(boy2.Name + ": 과자 맛있겠다! 고마워요!");
                    boy2.Affection += 10;
                }
                else if (give == 3)
                {
                    Console.WriteLine(boy3.Name + ": 마침 출출했는데 잘 됐다 고마워!!");
                    boy3.Affection += 10;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
            if (selectpresent == 2)
            {
                if (me.Money < 50000)
                {
                    Console.WriteLine("돈이 부족합니다..");
                    return;
                }
                me.Money -= 50000;
                Console.Write("팔찌를 누구에게 선물할까요? (1)boy1 (2)boy2 (3)boy3: ");
                int give = int.Parse(Console.ReadLine());
                Hour += 2;

                if (give == 1)
                {
                    Console.WriteLine(boy1.Name + ": 오 이거 예쁘다 잘 차고 다닐게 고마워!!");
                    boy1.Affection += 30;
                }
                else if (give == 2)
                {
                    Console.WriteLine(boy2.Name + ": 어... 고맙게 받을게요..!");
                    boy2.Affection += 10;
                }
                else if (give == 3)
                {
                    Console.WriteLine(boy3.Name + ": 내가 팔찌는 잘 안 차. 미안하지만 마음만 고맙게 받을게.");
                    boy3.Affection -= 5;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            }
            if (selectpresent == 3)
            {
                if (me.Money < 30000)
                {
                    Console.WriteLine("돈이 부족합니다..");
                    return;
                }
                me.Money -= 30000;
                Console.Write("모자를 누구에게 선물할까요? (1)boy1 (2)boy2 (3)boy3: ");
                int give = int.Parse(Console.ReadLine());
                Hour += 2;

                if (give == 1)
                {
                    Console.WriteLine(boy1.Name + ": 이건 너한테 더 어울릴 것 같은데.. 마음만 고맙게 받을게");
                    boy1.Affection -= 10;
                }
                else if (give == 2)
                {
                    Console.WriteLine(boy2.Name + ": 마음만 고맙게 받을게요..!!");
                    boy2.Affection -= 5;
                }
                else if (give == 3)
                {
                    Console.WriteLine(boy3.Name + ": 안 그래도 모자를 잃어버린 참이었어. 고맙게 잘 쓸게!!");
                    boy3.Affection += 20;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            }
            if (selectpresent == 4)
            {
                if (me.Money < 20000)
                {
                    Console.WriteLine("돈이 부족합니다..");
                    return;
                }
                me.Money -= 20000;
                Console.Write("키링을 누구에게 선물할까요? (1)boy1 (2)boy2 (3)boy3: ");
                int give = int.Parse(Console.ReadLine());
                Hour += 2;

                if (give == 1)
                {
                    Console.WriteLine(boy1.Name + ": 뽀삐 선물이야? 뽀삐가 좋아하겠다!");
                    boy1.Affection += 10;
                }
                else if (give == 2)
                {
                    Console.WriteLine(boy2.Name + ": 와! 너무 귀여워요! 가방에 잘 달고 다닐게요 고마워요!!");
                    boy2.Affection += 5;
                }
                else if (give == 3)
                {
                    Console.WriteLine(boy3.Name + "은 아무말 없이 키링을 내 가방에 달아주었다.");
                    boy3.Affection -= 5;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            }
        }
        public void GoToCatCafe(Me me)
        {
            if (me.Money < 30000)
            {
                Console.WriteLine("돈이 부족합니다..");
                return;
            }
            Console.WriteLine("---------------");
            Console.WriteLine("고양이 카페에 왔습니다!");
            Thread.Sleep(1000);
            Console.WriteLine("고양이를 쓰다듬으니 힐링됩니다..");
            Thread.Sleep(1000);
            Console.WriteLine("스트레스가 30 줄어들고, 체력이 50 회복됩니다!");
            me.Stress -= 30;
            me.HP += 30;
            me.Money -= 30000;
        }
        public void GoToHairShop(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            if (me.Money < 40000)
            {
                Console.WriteLine("돈이 부족합니다!");
                return;
            }
            Console.WriteLine("---------------");
            Console.WriteLine("미용실에 갑니다!");
            Thread.Sleep(1500);
            Console.WriteLine("조금 예뻐진 것 같습니다!");
            me.Money -= 40000;
            hour += 3;
            boy1.Affection += 15;
            boy2.Affection += 15;
            boy3.Affection += 15;

        }
        public void PrintAction(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3, int selectaction)
        {

            if (selectaction == 1)
            {
                me.PrintMyStat();
                CheckStat(me);
                PrintTime();
            }
            else if (selectaction == 2)
            {
                OutSide(me, boy1, boy2, boy3);
                CheckStat(me);
                PrintTime();
            }
            else if (selectaction == 3)
            {
                Work(me);
                CheckStat(me);
                PrintTime();
            }
            else if (selectaction == 4)
            {
                GoToHairShop(me, boy1, boy2, boy3);
                CheckStat(me);
                PrintTime();

            }
            else if (selectaction == 5)
            {
                GoToCatCafe(me);
            }
            else if (selectaction == 6)
            {
                Console.WriteLine("잠을 잡니다..");
                Thread.Sleep(1500);
                me.HP = 200;
                me.Stress -= 30;
                day += 1;
                hour = 0;
                Console.WriteLine("아침이 밝았습니다!");
                PrintTime();
            }

        }
        public void OutSide(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.Write("어디로 갈까요? (1)남주의 일터 (2)피시방 (3)노래방 (4)애견카페 (5)쇼핑센터 (6)돌아가기: ");
            int selectoutside = int.Parse(Console.ReadLine());

            if (selectoutside == 1)
            {
                GoToWorkSite(me, boy1, boy2, boy3);
            }
            else if (selectoutside == 2)
            {
                GoToPcCafe(me, boy1, boy2, boy3);
            }
            else if (selectoutside == 3)
            {
                GoToKagaoke(me, boy1, boy2, boy3);
            }
            else if (selectoutside == 4)
            {
                GoToDogCafe(me, boy1, boy2, boy3);
            }
            else if (selectoutside == 5)
            {
                GoToShoppingCenter(me, boy1, boy2, boy3);
            }
            else if (selectoutside == 6) return;
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

        }
        public void Work(Me me)
        {
            Console.WriteLine("---------------");
            Console.Write("무슨 알바를 할까요? (1)쿠팡 (2)과외 (3)카페: ");
            int selectwork = int.Parse(Console.ReadLine());

            if (selectwork == 1)
            {
                if (me.HP <= 70)
                {
                    Console.WriteLine("체력이 부족해 쿠팡 알바를 할 수 없습니다.");
                    return;
                }
                else
                {
                    Console.WriteLine("쿠팡을 하러 갑니다.");
                    Thread.Sleep(1500);
                    me.Money += 20000;
                    me.HP -= 70;
                    Hour += 8;
                    me.Stress += 30;
                    Console.WriteLine("20000원을 벌었습니다!");
                    me.PrintStat();
                    PrintTime();
                    return;
                }
            }
            else if (selectwork == 2)
            {
                if (teachingcount >= 1)
                {
                    Console.WriteLine("이미 과외를 1회 진행했습니다.");
                    return;
                }

                if (me.HP <= 35)
                {
                    Console.WriteLine("오늘은 더 이상 알바를 할 수 없습니다.");
                    return;
                }
                else
                {
                    Console.WriteLine("과외를 합니다.");
                    Thread.Sleep(1500);
                    me.Money += 50000;
                    me.HP -= 35;
                    Hour += 3;
                    me.Stress += 15;
                    teachingcount++;
                    Console.WriteLine("50000원을 벌었습니다!");
                    me.PrintStat();
                    PrintTime();
                    return;
                }

            }
            else if (selectwork == 3)
            {
                if (me.HP <= 45)
                {
                    Console.WriteLine("체력이 부족해 카페 알바를 할 수 없습니다.");
                }
                else
                {
                    Console.WriteLine("카페 알바를 합니다.");
                    Thread.Sleep(1500);
                    me.Money += 10000;
                    me.HP -= 45;
                    Hour += 5;
                    me.Stress += 20;
                    Console.WriteLine("10000원을 벌었습니다!");
                    me.PrintStat();
                    PrintTime();
                    return;
                }
            }
        }
        public void CheckStat(Me me)
        {
            if (hour >= 24 || me.Stress >= 100)
            {
                Console.WriteLine("잠을 자야합니다!");
                return;
            }
        }
        public void Confession(Me me, Boy1 boy1, Boy2 boy2, Boy3 boy3)
        {
            Console.WriteLine("고백의 시간입니다! 누구에게 고백할지 생각해보셨나요?");
            Thread.Sleep(2000);
            Console.Write("누구에게 고백하시겠습니까?: (1)boy1 (2)boy2 (3)boy3");
            int selectconfession = int.Parse(Console.ReadLine());

            if (selectconfession == 1)
            {
                if (boy1.Affection < 80)
                {
                    Console.WriteLine($"{me.Name}: {boy1.Name}.. 널 좋아해!! ");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy1.Name}: ....");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy1.Name}: {me.Name}... 난 널 좋은 소꿉친구라고 생각해..");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy1.Name}에게 차였습니다!");
                    return;
                }
                else if (boy1.Affection >= 80)
                {
                    Console.WriteLine($"{me.Name}: {boy1.Name}.. 널 좋아해!! ");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy1.Name}: ....");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy1.Name}: {me.Name}.. 나도 널 좋아해..!");
                    Thread.Sleep(1500);
                    Console.WriteLine("고백에 성공했습니다! 축하합니다!");
                    me.Love = true;
                }
            }
            if (selectconfession == 2)
            {
                if (boy2.Affection < 80)
                {
                    Console.WriteLine($"{me.Name}: {boy2.Name}.. 널 좋아해!! ");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy2.Name}: 네..? 저희 그냥 좋은 친구사이 아니었어요?");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy2.Name}에게 차였습니다!");
                    Thread.Sleep(1500);
                    return;
                }
                else if (boy2.Affection >= 80)
                {
                    Console.WriteLine($"{me.Name}: {boy2.Name}.. 널 좋아해!! ");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy2.Name}: ....");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy2.Name}: 저도 사실 누나가 좋아요..!");
                    Thread.Sleep(1500);
                    Console.WriteLine("고백에 성공했습니다! 축하합니다!");
                    me.Love = true;
                }
            }
            if (selectconfession == 3)
            {
                if (boy3.Affection < 80)
                {
                    Console.WriteLine($"{me.Name}: {boy3.Name}선배 좋아해요!!");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy3.Name}: ....");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy3.Name}: {me.Name}... 난 널 좋은 후배 이상으로 생각해 본 적 없어..");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy3.Name}에게 차였습니다!");
                    return;
                }
                else if (boy3.Affection >= 80)
                {
                    Console.WriteLine($"{me.Name}: {boy3.Name}선배 좋아해요!!");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy3.Name}: ....");
                    Thread.Sleep(1500);
                    Console.WriteLine($"{boy3.Name}: {me.Name}, 나도 니가 좋아");
                    Thread.Sleep(1500);
                    Console.WriteLine("고백에 성공했습니다! 축하합니다!");
                    me.Love = true;
                }
            }
        }
        public void PrintTime()
        {
            Console.WriteLine($"현재 시각: {Day}일 {Hour}시");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boy1 boy1 = new Boy1();
            Boy2 boy2 = new Boy2();
            Boy3 boy3 = new Boy3();
            Me me = new Me();
            Game game = new Game();
            Console.Write("플레이어의 이름은?: ");
            me.Name = Console.ReadLine();
            boy1.PrintStory();
            boy2.PrintStory();
            boy3.PrintStory();
            me.PrintStory();

            while (true)
            {

                Console.WriteLine("===============");
                Console.Write("무엇을 하시겠습니까? (1)내 정보 (2)외출 (3)알바 (4)자기 개발 (5)스트레스 풀기 (6)잠자기: ");
                game.PrintAction(me, boy1, boy2, boy3, game.SelectAction());

                if ((game.Hour >= 24 || me.HP <= 0) && game.SelectAction() != 6)
                {
                    Console.WriteLine("자야합니다!!");
                    Console.WriteLine("===============");
                }
                else if (me.Stress >= 100 && game.SelectAction() != 5 && game.SelectAction() != 6)
                {
                    Console.WriteLine("자거나 스트레스를 풀어야 합니다!");
                    Console.WriteLine("===============");
                }
                if (game.Day >= 30)
                {
                    game.Confession(me, boy1, boy2, boy3);
                    if (me.Love == true) break;
                    else continue;
                }

            }

        }
    }
}
