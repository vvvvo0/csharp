using System;
using System.Collections.Generic;

/*
중첩 클래스: 클래스 안에 선언되어 있는 클래스
자신이 소속도니 클래스의 멤버에 자유롭게 접근 가능.
심지어 private 멤버에도 접근 가능.
왜 쓰냐? 클래스 외부에 공개하고 싶지 않은 형식 만들 때,
혹은 현재 클래스의 일부분처럼 표현할 수 있는 클래스를 만들 때.
즉, 유연한 표현력이 장점.
단 은닉성 무너뜨리므로 조심.
 */

namespace NestedClass
{
    class Configuration
    {
        List<ItemValue> listConfig = new List<ItemValue>(); // ?

        public void SetConfig(string item, string value)
        {
            ItemValue iv = new ItemValue();
            iv.SetValue(this, item, value);
        }

        public string GetConfig(string item)
        {
            foreach (ItemValue iv in listConfig)
            {
                if (iv.GetItem() == item)
                    return iv.GetValue();
            }

            return "";
        }

        private class ItemValue // Configuration 클래스 안에 선언된 중첩 클래스.
                                // private로 선언했으므로 Configuration 클래스 밖에서는 안 보임.
        {
            private string item;
            private string value;

            public void SetValue(Configuration config, string item, string value)
            {
                this.item = item;
                this.value = value;

                bool found = false;
                for (int i = 0; i < config.listConfig.Count; i++) // 중첩 클래스는 상위 클래스의 멤버에 자유롭게 접근 가능.
                {
                    if (config.listConfig[i].item == item)
                    {
                        config.listConfig[i] = this;
                        found = true;
                        break;
                    }
                }

                if (found == false)
                    config.listConfig.Add(this);
            }

            public string GetItem()
            { return item; }
            public string GetValue()
            { return value; }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            config.SetConfig("Version", "V 5.0");
            config.SetConfig("Size", "655,324 KB");

            Console.WriteLine(config.GetConfig("Version"));
            Console.WriteLine(config.GetConfig("Size"));

            config.SetConfig("Version", "V 5.0.1");
            Console.WriteLine(config.GetConfig("Version"));
        }
    }
}
