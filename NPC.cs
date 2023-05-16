using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class NPC
    {
        public int skill_count_static = 2; // revive 용

        public int exp = 0;
        public int defend = 10;//방어력
        public int damage = 10;//공격력
        public int gold = 15; // 드랍할 골드
        public int max_health = 100;
        public int real_health = 100;

        public int item_str = 0;
        public int item_intel = 0;
        public int item_spd = 0;
        public int item_def = 0;

        public int str = 5;
        public int intel = 5;
        public int spd = 5;
        public int def = 5;

        public int skill_count = 2; // 스킬 사용가능한 횟수
        public string name;
        public Image img;
        public Image img_defend;
        public Image img_skill;
        public Image img_attack;
        public Image img_attacked;
        public Image img_dead;

        public int attack()
        {
            return damage + item_str;
        }

        public int defense(int dam)
        {
            dam = dam - (defend + item_def);
            real_health -= dam;
            if (real_health <= 0)
            {
                real_health = 0;
                return 0;
            }
            return 1;
        }
        public int damaged(int dam)
        {
            real_health -= dam;
            if (real_health <= 0)
            {
                real_health = 0;
                return 0;
            }
            return 1;
        }

        public int skill(string skill_name)
        {
            if (skill_count > 0)
            {
                if (skill_name == "")
                {
                    skill_count--;
                    return 20;
                }

            }
            return 0;
        }
        public void item_clear()
        {
            item_str = 0;
            item_intel = 0;
            item_spd = 0;
            item_def = 0;
        }
        public void revive()
        {
            real_health = max_health;
            skill_count = skill_count_static;
        }

        public class wiz
        {
            public int wiz_visit = 0;
        }

    }
    public class slime : NPC
    {
        public slime()
        {
            name = "슬라임";
            img = Image.FromFile(".\\img\\slim.png");
            img_attack = Image.FromFile(".\\img\\slim_attack.png");
            img_defend = Image.FromFile(".\\img\\slim_defend.png");
            img_attacked = Image.FromFile(".\\img\\slim_attacked.png");
            img_skill = Image.FromFile(".\\img\\slim_skill.png");
            img_dead = Image.FromFile(".\\img\\slim_dead.png");
            max_health = 100;
            real_health = 100;
            defend = 10;
            damage = 10;

            skill_count_static = 2;
            skill_count = skill_count_static;
            exp = 80;
        }
        public new int skill(string skill_name)
        {
            if (skill_count > 0)
            {
                if (skill_name == "깨물기")
                {
                    skill_count--;
                    return 20;
                }

            }
            return 0;
        }
    }



}
