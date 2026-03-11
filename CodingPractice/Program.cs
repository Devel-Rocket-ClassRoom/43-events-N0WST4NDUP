using System;

// 1. 대리자 복습
// Notify notify = SayHello;
// notify += SayGoodBye;

// void SayHello() => Console.WriteLine("안녕하세요!");
// void SayGoodBye() => Console.WriteLine("안녕히 가세요!");

// delegate void Notify();

// 2. 기본 이벤트 선언
// Button btn = new();

// btn.Click += HandleClick;
// btn.Click += HandleClickAgain;

// btn.OnClick();

// static void HandleClick()
// {
//     Console.WriteLine("버튼이 클릭되었습니다!");
// }

// static void HandleClickAgain()
// {
//     Console.WriteLine("클릭 처리 완료");
// }

// delegate void EventHandler();

// class Button
// {
//     public event EventHandler Click;

//     public void OnClick() => Click?.Invoke();

// }

// 3. 이벤트 구독
// Player player = new Player();
// HealthBar healthBar = new HealthBar();
// SoundManager soundManager = new SoundManager();

// player.DamageTaken += healthBar.OnPlayerDamaged;
// player.DamageTaken += soundManager.OnPlayerDamaged;

// player.TakeDamage(30);

// class Player
// {
//     private int _health = 100;
//     public event Action<int> DamageTaken;
//     public void TakeDamage(int dmg)
//     {
//         _health = Math.Max(0, _health - dmg);
//         Console.WriteLine($"플레이어 체력: {_health}");
//         DamageTaken?.Invoke(_health);
//     }
// }

// class HealthBar
// {
//     public void OnPlayerDamaged(int currentHealth)
//     {
//         Console.WriteLine($"[UI] 체력바 업데이트: {currentHealth}%");
//     }
// }

// class SoundManager
// {
//     public void OnPlayerDamaged(int currentHealth)
//     {
//         Console.WriteLine("[Sound] 피격 효과음 재생");
//     }
// }

// 4. 이벤트 해제
// Timer timer = new Timer();
// Logger logger = new Logger();

// timer.Tick += logger.OnTick;

// Console.WriteLine("=== 구독 상태 ===");
// timer.Start();

// timer.Tick -= logger.OnTick;

// Console.WriteLine("\n=== 구독 해제 후 ===");
// timer.Start();

// class Timer
// {
//     public event Action Tick;
//     private int _count;

//     public void Start()
//     {
//         for (int i = 0; i < 3; i++)
//         {
//             _count++;
//             Console.WriteLine($"타이머: {_count}초");
//             Tick?.Invoke();
//         }
//     }
// }

// class Logger
// {
//     public void OnTick()
//     {
//         Console.WriteLine("[Logger] 틱 기록됨");
//     }
// }

// 5. 람다식 이벤트 핸들러
// Sensor sensor = new();
// sensor.Alert += (msg) => Console.WriteLine($"[경보] {msg}");
// sensor.Alert += (msg) => Console.WriteLine($"[로그] {DateTime.Now} {msg}");

// sensor.Detect("움직임 감지됨");
// sensor.Detect("온도 상승");

// class Sensor
// {
//     public event Action<string> Alert;

//     public void Detect(string msg)
//     {
//         Console.WriteLine($"감지: {msg}");
//         Alert?.Invoke(msg);
//     }
// }

// 6. Action 대리자 활용
// GameCharacter hero = new("용사");

// hero.OnDeath += () => Console.WriteLine("캐릭터가 사망했습니다");
// hero.OnDamaged += health => Console.WriteLine($"남은 체력: {health}");
// hero.OnAttack += (damage, target) =>
//     Console.WriteLine($"{target}에게 {damage} 데미지!");

// hero.Attack(50, "슬라임");
// hero.TakeDamage(30);
// hero.TakeDamage(80);

// class GameCharacter
// {
//     private int _health = 100;
//     private string _name;

//     public event Action OnDeath;
//     public event Action<int> OnDamaged;
//     public event Action<int, string> OnAttack;

//     public GameCharacter(string name) => _name = name;

//     public void TakeDamage(int dmg)
//     {
//         _health = Math.Max(0, _health - dmg);
//         OnDamaged?.Invoke(_health);

//         if (_health == 0) OnDeath?.Invoke();
//     }

//     public void Attack(int damage, string targetName)
//     {
//         OnAttack?.Invoke(damage, targetName);
//     }
// }

// 7. 표준 이벤트 패턴 (EventArgs)
// Stock stock = new("MSFT", 100);

// stock.PriceChanged += (sender, e) =>
// {
//     Stock stock = (Stock)sender;
//     Console.WriteLine($"[{stock}]");
//     Console.WriteLine($"  이전 가격: {e.OldPrice:C}");
//     Console.WriteLine($"  현재 가격: {e.NewPrice:C}");
//     Console.WriteLine($"  변동률: {e.ChangePercent:F2}%");
//     Console.WriteLine();
// };

// stock.Price = 110;
// stock.Price = 106;
// stock.Price = 120;

// class Stock
// {
//     private string _ticker;
//     private decimal _price;

//     public event EventHandler<PriceChangedEventArgs> PriceChanged;
//     public decimal Price
//     {
//         get => _price;
//         set
//         {
//             if (_price == value)
//             {
//                 return;
//             }

//             decimal oldPrice = _price;
//             _price = value;

//             OnChanged(new PriceChangedEventArgs(oldPrice, _price));
//         }
//     }

//     public Stock(string ticker, decimal price)
//     {
//         _ticker = ticker;
//         _price = price;
//     }

//     public void OnChanged(PriceChangedEventArgs e) => PriceChanged?.Invoke(this, e);

//     public override string ToString()
//     {
//         return $"{_ticker}: {_price:C}";
//     }
// }

// class PriceChangedEventArgs : EventArgs
// {
//     public decimal OldPrice { get; }
//     public decimal NewPrice { get; }
//     public decimal ChangePercent { get; }

//     public PriceChangedEventArgs(decimal oldPrice, decimal newPrice)
//     {
//         OldPrice = oldPrice;
//         NewPrice = newPrice;
//         if (oldPrice != 0)
//         {
//             ChangePercent = (newPrice - oldPrice) / oldPrice * 100;
//         }
//     }
// }

// 8. 실전 예제 - 연료 경고 시스템
// Car car = new(50);
// Dashboard dashboard = new();

// dashboard.Subscribe(car);

// for (int i = 0; i < 7; i++)
// {
//     car.Drive();
//     Console.WriteLine();
// }

// dashboard.Unsubscribe(car);

// class FuelEventArgs : EventArgs
// {
//     public int FuelLevel { get; }
//     public string Warning { get; }

//     public FuelEventArgs(int fuelLevel, string warning)
//     {
//         FuelLevel = fuelLevel;
//         Warning = warning;
//     }
// }

// // 게시자: 자동차
// class Car
// {
//     private int _fuelLevel;

//     public event EventHandler<FuelEventArgs> FuelLow;
//     public event Action<int> FuelChanged;

//     public Car(int initialFuel)
//     {
//         _fuelLevel = initialFuel;
//     }

//     public int FuelLevel => _fuelLevel;

//     public void Drive()
//     {
//         if (_fuelLevel <= 0)
//         {
//             Console.WriteLine("연료 없음! 운전 불가");
//             return;
//         }

//         _fuelLevel -= 10;
//         Console.WriteLine($"운전 중... 연료: {_fuelLevel}%");

//         FuelChanged?.Invoke(_fuelLevel);

//         if (_fuelLevel <= 0)
//         {
//             OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 바닥났습니다!"));
//         }
//         else if (_fuelLevel <= 20)
//         {
//             OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 부족합니다"));
//         }
//     }

//     protected virtual void OnFuelLow(FuelEventArgs e)
//     {
//         FuelLow?.Invoke(this, e);
//     }
// }

// class Dashboard
// {
//     public void Subscribe(Car car)
//     {
//         car.FuelChanged += OnFuelChanged;
//         car.FuelLow += OnFuelLow;
//     }

//     public void Unsubscribe(Car car)
//     {
//         car.FuelChanged -= OnFuelChanged;
//         car.FuelLow -= OnFuelLow;
//     }

//     private void OnFuelChanged(int fuelLevel)
//     {
//         string gauge = new string('█', fuelLevel / 10);
//         Console.WriteLine($"[대시보드] 연료 게이지: {gauge}");
//     }

//     private void OnFuelLow(object sender, FuelEventArgs e)
//     {
//         Console.ForegroundColor = ConsoleColor.Red;
//         Console.WriteLine($"[경고!] {e.Warning} (잔량: {e.FuelLevel}%)");
//         Console.ResetColor();
//     }
// }

// 9. 이벤트 접근자
// class SecurePublisher
// {
//     private EventHandler _myEvent;
//     private readonly object _lock = new object();

//     public event EventHandler MyEvent
//     {
//         add
//         {
//             lock (_lock)
//             {
//                 Console.WriteLine($"구독자 추가: {value.Method.Name}");
//                 _myEvent += value;
//             }
//         }
//         remove
//         {
//             lock (_lock)
//             {
//                 Console.WriteLine($"구독자 제거: {value.Method.Name}");
//                 _myEvent -= value;
//             }
//         }
//     }

//     public void RaiseEvent()
//     {
//         _myEvent?.Invoke(this, EventArgs.Empty);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         SecurePublisher publisher = new SecurePublisher();

//         publisher.MyEvent += Handler1;
//         publisher.MyEvent += Handler2;

//         Console.WriteLine("\n이벤트 발생:");
//         publisher.RaiseEvent();

//         Console.WriteLine();
//         publisher.MyEvent -= Handler1;

//         Console.WriteLine("\n이벤트 발생:");
//         publisher.RaiseEvent();
//     }

//     static void Handler1(object sender, EventArgs e)
//     {
//         Console.WriteLine("Handler1 실행됨");
//     }

//     static void Handler2(object sender, EventArgs e)
//     {
//         Console.WriteLine("Handler2 실행됨");
//     }
// }

// 10. static 이벤트
class GlobalNotifier
{
    public static event Action<string> OnGlobalMessage;

    public static void SendMessage(string message)
    {
        Console.WriteLine($"[Global] 메시지 전송: {message}");
        OnGlobalMessage?.Invoke(message);
    }
}

class Module1
{
    public Module1()
    {
        GlobalNotifier.OnGlobalMessage += HandleMessage;
    }

    private void HandleMessage(string message)
    {
        Console.WriteLine($"[Module1] 수신: {message}");
    }
}

class Module2
{
    public Module2()
    {
        GlobalNotifier.OnGlobalMessage += HandleMessage;
    }

    private void HandleMessage(string message)
    {
        Console.WriteLine($"[Module2] 수신: {message}");
    }
}

class Program
{
    static void Main()
    {
        Module1 m1 = new Module1();
        Module2 m2 = new Module2();

        GlobalNotifier.SendMessage("시스템 시작");
        Console.WriteLine();
        GlobalNotifier.SendMessage("데이터 로드 완료");
    }
}