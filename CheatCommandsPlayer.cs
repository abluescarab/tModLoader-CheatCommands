using CheatCommands.Commands.Player;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatCommands {
    class CheatCommandsPlayer : ModPlayer {        
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if(GodMode.Enabled) { 
                return false;
            }

            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource) {
            if(GodMode.Enabled) {
                return false;
            }

            return base.PreKill(damage, hitDirection, pvp, ref playSound, ref genGore, ref damageSource);
        }

        public override bool CanBeHitByProjectile(Projectile proj) {
            if(GodMode.Enabled) {
                return false;
            }

            return base.CanBeHitByProjectile(proj);
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo) {
            if(InfiniteAmmo.Enabled) {
                return false;
            }

            return base.ConsumeAmmo(weapon, ammo);
        }
        
        public override void PreUpdateBuffs() {
            if(GodMode.Enabled) {
                RemoveDebuffs();
            }
        }

        public override void PostUpdateMiscEffects() {
            if(GodMode.Enabled) {
                RefillMana(false);
            }
        }
        
        public void RefillLife() {
            player.statLife = player.statLifeMax2;
            player.HealEffect(player.statLifeMax2, true);
        }

        public void RefillMana(bool showEffect) {
            player.statMana = player.statManaMax2;

            if(showEffect) {
                player.ManaEffect(player.statManaMax2);
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
