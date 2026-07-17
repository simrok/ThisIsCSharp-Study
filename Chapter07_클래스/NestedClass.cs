// 예제의 목적: Configuration 클래스 안에서만 사용하는 ItemValue 클래스를 보여줌
// Configuration config = new Configuration();은 가능하지만
// ItemValue iv = new ItemValue();는 불가함.
// 그 이유는 private calss ItemValue이기 때문.

// 예시이기 때문에 이렇게 작성하는 것. 실제로 키ㅡ값을 사용하는거라면 딕셔너리를 사용하는 것이 효율적임.

using System;
using System.Collections.Generic;

namespace NestedClass
{
	class Configuration
	{
		List<ItemValue> listConfig = new List<ItemValue>(); // configuration 객체 생성 시 생성되는 리스트

		public void SetConfig(string item, string value)    // 환경 설정
		{
			ItemValue iv = new ItemValue();
			iv.SetValue(this, item, value); // itemValue객체.SetValue 메소드
											// => 여기서 this는 현재 Configuration 객체
											// 왜 Config 객체를 넘기는가?
											// ItemValue는 Configuration 객체의 리스트인 listConfig를 수정해야 하기 때문
		}

		public string GetConfig(string item)
		{
			foreach (ItemValue iv in listConfig)        // listConfig 리스트 안의 ItemValue 객체 개수만큼 반복
			{
				if (iv.GetItem() == item)   // iv에 item이 있으면
					return iv.GetValue();   // 해당 ItemValue의 value값 return
			}

			return "";  // iv에 해당 item이 없으면 return "";
		}

		private class ItemValue     // 클래스 안 클래스 == 중첩 클래스
									// Configuration 안에서만 사용하는 보조 클래스
									// 리스트 안의 ItemValue 객체를 만들기 위한 클래스

		{
			private string item;
			private string value;

			public void SetValue(Configuration config, string item, string value)
			{
				this.item = item;
				this.value = value;

				bool found = false;
				for (int i = 0; i < config.listConfig.Count; i++)   // config 객체의 listConfig의 개수만큼 반복
				{
					if (config.listConfig[i].item == item)  // config 객체의 listConfig 리스트 안의 i번째 요소.item이 == item이면
					{
						config.listConfig[i] = this;    // 이 this는 현재 ItemValue 객체인 iv
														// 즉, item 값이 똑같으면 ItemValue 교체
						found = true;   // 찾음 true
						break;     
					}
				}

				if (found == false)     // for문 다 돌렸는데도 못찾으면
					config.listConfig.Add(this);    // config 객체의 리스트에 this(현재 ItemValue 객체)를 추가
			}

			public string GetItem() // item 리턴하기
			{ return item; }
			public string GetValue()    // value 리턴하기
			{ return value; }
		}
	}


	class MainApp
	{
		static void Run()
		{
			Configuration config = new Configuration(); // 새로운 Configuration 객체 생성
			config.SetConfig("Version", "V 5.0");   // ItemValue인 iv를 만들고  SetValue(this, item, value)가 됨
													// > 리스트에 해당 ItemValue가 없으면 리스트에 추가
													// [0] item = "version" value = "V 5.0"
			config.SetConfig("Size", "655,324 KB"); // [1] item = "Size" value = "655,324 KB"

			Console.WriteLine(config.GetConfig("Version")); // ItemValue 객체 중에서 "version"이라는 item을 가지고 있는 객체가 있으면 그 객체의 value값을 리턴
			Console.WriteLine(config.GetConfig("Size"));

			config.SetConfig("Version", "V 5.0.1"); // item 값 겹침 > 따라서 ItemValue 교체됨
			Console.WriteLine(config.GetConfig("Version")); // 따라서 V 5.0.1 출력됨
		}
	}
}