using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WinFormsApp_ServiceBus
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		MqttClient mqttClient = null;
		Boolean connectStatus = false;

		String server = "150.95.112.175";  // txtServer.Text;
		int port = 1883;
		String topic = "a1908g";

		delegate void Mydelega(String message);
		event Mydelega MyReceive;

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnCon_Click(object sender, EventArgs e)
		{
			if(mqttClient== null)
			{
				mqttClient = new MqttClient(server, port, false, MqttSslProtocols.TLSv1_0, null, null);
			}
			if(mqttClient != null && mqttClient.IsConnected == false)
			{
				String clientId = Guid.NewGuid().ToString();
				mqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
				mqttClient.Connect(clientId);
				mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

				this.richText_Info.Text += "\n" + clientId;
			}
			this.Text = "Da ket noi" + mqttClient.IsConnected;
			
			
		}

		void Subscriable() //dang ky kenh
		{
			if (mqttClient != null && mqttClient.IsConnected)
			{
				String[] topics = { topic, "a1908g2" };
				byte[] myByte = new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
				mqttClient.Subscribe(topics, myByte);
				MessageBox.Show("Da Subscribe Topic" + topic);
			}
		}

		private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
		{
			byte[] dataNhanVe = e.Message;
			String data = System.Text.ASCIIEncoding.UTF8.GetString(dataNhanVe);
			MyReceive = new Mydelega(ReceiveData);
			this.Invoke(MyReceive, new String[] { data}); //goi ham Receive, tra ve mang data
		}
		void ReceiveData(String data)
		{
			this.richText_Info.Text += "\n" + data;
		}

		private void btnSub_Click(object sender, EventArgs e)
		{
			Subscriable(); //goi ham de dang ky kenh, chu de topic.
		}

		private void btn_open_Click(object sender, EventArgs e)
		{
			FormSend fs = new FormSend();
			fs.Show();
		}
	}
}
