using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class C_1_2_2 : Form
    {
        public C_1_2_2()
        {
            InitializeComponent();
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@form 복사시에 아래 부분 복사 후 Form2 를 새로 만든 폼 이름으로 바꿀것.
        //해당 부분 copy 필요
        public int visit = 0;
        public character ch;
        public slime slime = new slime();
        public C_1_2_2(ref character character)
        {


            //string name = "슬라임";
            //slime.name = name;
            ch = character;

            InitializeComponent();


            setting(character);
            item_btn_enable();
            act_btn_enable();
            picture_main.Image = character.main;
            //picture_npc.Image = slime.img;
            //스킬 옮겨 담기
            for (int i = 0; i < character.skill_count; i++)
            {
                cmb_skill.Items.Add(character.skill[i]);
            }


        }

        //폼 로딩시 세팅 단계
        public void setting(character character)
        {
            //따로 추가

            //npc_name.Text = slime.name;
            //npc_health.Text = slime.real_health.ToString();
            //따로 추가
            if (character.item_str > 0)
            {
                str.Text = character.str.ToString() + " +" + character.item_str.ToString();
            }
            else
            {
                str.Text = character.str.ToString();
            }
            if (character.item_intel > 0)
            {
                intel.Text = character.intel.ToString() + " +" + character.item_intel.ToString();
            }
            else
            {
                intel.Text = character.intel.ToString();
            }
            if (character.item_spd > 0)
            {
                spd.Text = character.spd.ToString() + " +" + character.item_spd.ToString();
            }
            else
            {
                spd.Text = character.spd.ToString();
            }
            if (character.item_def > 0)
            {
                def.Text = character.def.ToString() + " +" + character.item_def.ToString();
            }
            else
            {
                def.Text = character.def.ToString();
            }

            item_btn_able(ch);
            label2.Text = ch.skill_point.ToString();
            name.Text = character.name;
            exp.Text = character.exp_per.ToString() + '%';
            leb.Text = character.leb.ToString();
            point.Text = character.stat_point.ToString();
            real_health.Text = character.real_health.ToString() + " / " + character.max_health.ToString();

            if (character.stat_point < 1)
            {
                stat_btn_setting(false);
            }
            else
            {
                stat_btn_setting(true);
            }

        }
        //공격, 방어, 스킬, 도망 버튼 비활성화
        public void act_btn_enable()
        {
            btn_attack.Enabled = false;
            btn_defend.Enabled = false;
            btn_skill.Enabled = false;
            btn_run.Enabled = false;
        }
        //공격, 방어, 스킬, 도망 버튼 활성화
        public void act_btn_able()
        {
            btn_attack.Enabled = true;
            btn_defend.Enabled = true;
            btn_skill.Enabled = true;
            btn_run.Enabled = true;
        }

        //stat 포인트에 따라 버튼 활성화 , 비활성화
        public void stat_btn_setting(bool bl)
        {
            if (bl)
            {
                btn_str.Enabled = true;
                btn_intel.Enabled = true;
                btn_spd.Enabled = true;
                btn_def.Enabled = true;
            }
            else
            {

                btn_str.Enabled = false;
                btn_intel.Enabled = false;
                btn_spd.Enabled = false;
                btn_def.Enabled = false;
            }
        }
        //아이템 버튼 비활성화 하기
        public void item_btn_enable()
        {
            item_1.Text = ch.item_have(0).ToString();
            item_2.Text = ch.item_have(1).ToString();
            item_3.Text = ch.item_have(2).ToString();
            item_4.Text = ch.item_have(3).ToString();
            item_5.Text = ch.item_have(4).ToString();
            item_6.Text = ch.item_have(5).ToString();
            item_7.Text = ch.item_have(6).ToString();
            item_8.Text = ch.item_have(7).ToString();

            btn_item_1.Enabled = false;
            btn_item_2.Enabled = false;
            btn_item_3.Enabled = false;
            btn_item_4.Enabled = false;
            btn_item_5.Enabled = false;
            btn_item_6.Enabled = false;
            btn_item_7.Enabled = false;
            btn_item_8.Enabled = false;
        }
        //업데이트 용
        public void update()
        {
            Thread.Sleep(100);
            setting(ch);
            Thread.Sleep(100);
        }
        public void move_btn_enable()
        {
            btn_down_move.Enabled = false;
            btn_left_move.Enabled = false;
            btn_right_move.Enabled = false;
            btn_up_move.Enabled = false;
        }
        private void btn_str_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name.ToString())
            {
                case "btn_str":
                    ch.str += 1;
                    ch.stat_use();
                    break;
                case "btn_intel":
                    ch.intel += 1;
                    ch.stat_use();
                    break;
                case "btn_spd":
                    ch.spd += 1;
                    ch.stat_use();
                    break;
                case "btn_def":
                    ch.def += 1;
                    ch.stat_use();
                    break;
                default:
                    break;
            }
            update();
        }


        public void move_btn_able()
        {
            btn_down_move.Enabled = true;
            btn_left_move.Enabled = true;
            btn_right_move.Enabled = true;
            btn_up_move.Enabled = true;
        }
        //아이템 버튼 활성화 하기
        public void item_btn_able(character character)
        {
            for (int i = 0; i < character.max_item; i++)
            {

                switch (i)
                {
                    case 0:
                        item_1.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_1.Enabled = true;
                        else
                            btn_item_1.Enabled = false;
                        break;
                    case 1:
                        item_2.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_2.Enabled = true;
                        else
                            btn_item_2.Enabled = false;

                        break;
                    case 2:
                        item_3.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_3.Enabled = true;
                        else
                            btn_item_3.Enabled = false;

                        break;
                    case 3:
                        item_4.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_4.Enabled = true;
                        else
                            btn_item_4.Enabled = false;

                        break;
                    case 4:
                        item_5.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_5.Enabled = true;
                        else
                            btn_item_5.Enabled = false;

                        break;
                    case 5:
                        item_6.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_6.Enabled = true;
                        else
                            btn_item_6.Enabled = false;

                        break;
                    case 6:
                        item_7.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_7.Enabled = true;
                        else
                            btn_item_7.Enabled = false;
                        break;
                    case 7:
                        item_8.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_8.Enabled = true;
                        else
                            btn_item_8.Enabled = false;
                        break;
                    default:
                        break;

                }

            }
        }

        private void btn_left_move_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void C_1_2_2_Load(object sender, EventArgs e)
        {
            if (ch.wiz_visit == 0)
            {
            npc_name.Text = "마법사";
            textBox1.Text += "저 멀리서 쓰러진 마법사가 보인다. 가까이 가볼까? \r\n";
            btn_attack.Visible = false;
            btn_defend.Visible = false;
            move_btn_enable();
            btn_yes.Visible = true;
            btn_no.Visible = true;
            picture_npc.Image = Image.FromFile(".\\img\\wiz_01.png");
            }
            else if (ch.wiz_visit == 1)
            {
                npc_name.Text = "마법사";
                textBox1.Text += "잃어버린 제 마법서를 찾아와주시면 감사하겠습니다... \r\n\r\n";
                textBox1.Text += "[ 현재 퀘스트를 수락한 상태입니다. ] \r\n";
                picture_npc.Image = Image.FromFile(".\\img\\wiz_02.png");
            }
            else if (ch.wiz_visit == 2)
            {
                ch.wiz_visit = 3;
                npc_name.Text = "마법사";
                textBox1.Text += "잃어버린 제 마법서를 찾아와주셔서 감사합니다! \r\n";
                textBox1.Text += "감사의 의미로 선물을 드릴게요! \r\n\r\n";
                textBox1.Text += "[exp 300 을 획득하였습니다.] \r\n[회복 포션 3개를 획득하였습니다.] ";
                for(int i = 0; i < 31; i++) ch.exp_gain(10);
                ch.item_gain(0, 3);
                picture_npc.Image = Image.FromFile(".\\img\\wiz_03.png");
                update();
            }
            else if (ch.wiz_visit == 3)
            {
                ch.wiz_visit = 3;
                npc_name.Text = "마법사";
                textBox1.Text += "잃어버린 제 마법서를 찾아와주셔서 감사합니다! \r\n";
                textBox1.Text += "이제 다시 모험을 떠날 수 있겠어요. \r\n\r\n";
                textBox1.Text += "[ 퀘스트를 완료하셨습니다. ] \r\n";
                picture_npc.Image = Image.FromFile(".\\img\\wiz_03.png");
            }

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            textBox1.Text += "\r\n으으... 구해주셔서 감사합니다. \r\n모험을 하던 도중 정체불명의 몬스터를 만나 잠시 정신을 잃게 되었습니다. \r\n";
            textBox1.Text += "몸 상태는 쉬면 괜찮아질 것 같지만....\r\n\r\n제 소중한 마법서를 몬스터가 있는 장소에 떨어뜨리고 왔습니다. \r\n";
            textBox1.Text += "혹시 몬스터를 물리치고 잃어버린 제 마법서를 찾아와주실 수 있을까요? 부탁드립니다. \r\n";
            picture_npc.Image = Image.FromFile(".\\img\\wiz_02.png");
            btn_yes.Visible = false;
            btn_quest_yes.Visible = true;
        }

        private void btn_quest_yes_Click(object sender, EventArgs e)
        {
            ch.wiz_visit = 1;
            MessageBox.Show("퀘스트를 수락하였습니다.\r\n그리고 C_1_2_3에 걸려있는 결계가 해제되었습니다.");
            this.Close();
        }


        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    }
}
