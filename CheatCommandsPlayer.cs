using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommandsPlayer : ModPlayer {
        private int _maxMana = 0;

        public bool GodMode { get; set; }
        public bool InfiniteAmmo { get; set; }
        public int MaxMana {
            get { return _maxMana; }
            set {
                _maxMana = value;
                ChangeMana();
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if(GodMode) {
                return false;
            }

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if(GodMode) {
                return false;
            }

            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }
        
        public override bool CanBeHitByProjectile(Projectile proj) {
            if(GodMode) {
                return false;
            }

            return base.CanBeHitByProjectile(proj);
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo) {
            if(InfiniteAmmo) {
                return false;
            }

            return base.ConsumeAmmo(weapon, ammo);
        }

        public override void OnEnterWorld(Player player) {
            MaxMana = (player.statManaMax2 > player.statManaMax ? player.statManaMax2 : player.statManaMax);
        }

        public override void PostUpdateMiscEffects() {
            ChangeMana();

            if(GodMode) {
                RemoveDebuffs();
                RefillMana(false);
            }
        }
        
        public void ChangeMana() {
            if(MaxMana >= 400) {
                player.statManaMax = 400;
            }

            player.statManaMax2 = MaxMana;
        }

        public void RefillLife() {
            int maxLife = (player.statLifeMax2 > player.statLifeMax ? player.statLifeMax2 : player.statLifeMax);

            player.statLife = maxLife;
            player.HealEffect(maxLife, true);
        }

        public void RefillMana(bool showEffect) {
            int maxMana = (player.statManaMax2 > player.statManaMax ? player.statManaMax2 : player.statManaMax);

            player.statMana = maxMana;

            if(showEffect) {
                player.ManaEffect(maxMana);
            }
        }

        public void RemoveDebuffs() {
            for(int i = 0; i < Main.debuff.Length; i++) {
                switch(i) {
                    case BuffID.Horrified:      // fighting Wall of Flesh
                    case BuffID.TheTongue:      // in contact with Wall of Flesh tongue
                    case BuffID.Obstructed:     // attacked by a Brain Suckler
                    case BuffID.Suffocation:    // in contact with silt/sand/slush
                    case BuffID.Burning:        // in contact with hot blocks
                    case BuffID.WaterCandle:    // around a water candle
                        break;
                    default:
                        if(Main.debuff[i]) {
                            player.ClearBuff(i);
                        }
                        break;
                }
            }
        }
    }
}
