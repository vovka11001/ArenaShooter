using System;
using R3;

public class RangedWeapon : IDisposable
{
   private readonly Subject<Unit> _triggerPulled = new Subject<Unit>();

   public RangedWeapon(GameConfig config)
   {
      Range = config.ShotRange;
      Fired = _triggerPulled.ThrottleFirst(TimeSpan.FromSeconds(config.FireCooldownSeconds));
   }
   
   public float Range { get; }
   public Observable<Unit> Fired { get; }

   public void PullTrigger()
   {
      _triggerPulled.OnNext(Unit.Default);
   }

   public void Dispose()
   {
      _triggerPulled.Dispose();
   }
}