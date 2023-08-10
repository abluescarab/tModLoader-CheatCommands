using CheatCommands.Commands.Player;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CheatCommands {
    class CheatCommandsPlayer : ModPlayer {
        public HomeList Homes { get; } = new HomeList();

        public override void SaveData(TagCompound tag) {
            Homes.SaveData(tag);
        }

        public override void LoadData(TagCompound tag) {
            Homes.LoadData(tag);
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers) {
            if(GodMode.Enabled) {
                modifiers.FinalDamage *= 0.0f;
            }

            if(Knockback.Enabled) {
                modifiers.HitDirectionOverride = 0;
            }

            base.ModifyHurt(ref modifiers);
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

        public override bool CanConsumeAmmo(Item weapon, Item ammo) {
            if(InfiniteAmmo.Enabled) {
                return false;
            }

            return base.CanConsumeAmmo(weapon, ammo);
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
            Player.statLife = Player.statLifeMax2;
            Player.HealEffect(Player.statLifeMax2, true);
        }

        public void RefillMana(bool showEffect) {
            Player.statMana = Player.statManaMax2;

            if(showEffect) {
                Player.ManaEffect(Player.statManaMax2);
            }
        }

        public void RemoveDebuffs() {
            for(int i = 0; i < Main.debuff.Length; i++) {
                // do not remove buffs
                if(!Main.debuff[i]) {
                    continue;
                }

                // do not clear any buffs that nurse cannot remove, except
                // certain ones (otherwise environmental buffs are cleared,
                // like banners and campfire)
                if(BuffID.Sets.NurseCannotRemoveDebuff[i]) {
                    switch(i) {
                        case BuffID.PotionSickness:
                        case BuffID.NeutralHunger:
                        case BuffID.Hunger:
                        case BuffID.Starving:
                            Player.ClearBuff(i);
                            break;
                        default:
                            continue;
                    }
                }

                // clear all other debuffs
                Player.ClearBuff(i);
            }
        }
    }
}
