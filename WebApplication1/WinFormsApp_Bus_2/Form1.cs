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

namespace WinFormsApp_Bus_2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		MqttClient mqttClient = null;
		String server = "150.95.112.175";  // txtServer.Text;
		int port = 1883;
		String topic = "a1908g";
		private void btn_Con_Click(object sender, EventArgs e)
		{
			if (mqttClient == null)
			{
				mqttClient = new MqttClient(server, port, false, MqttSslProtocols.TLSv1_0, null, null);
			}
			if (mqttClient != null && mqttClient.IsConnected == false)
			{
				String clientId = Guid.NewGuid().ToString();
				mqttClient.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
				mqttClient.Connect(clientId);
				//mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

				//this.richText_Info.Text += "\n" + clientId;
			}
			this.Text = "Da ket noi" + mqttClient.IsConnected;

		}

		private void button_send_data_Click(object sender, EventArgs e)
		{
			if (mqttClient != null && mqttClient.IsConnected)
			{
				byte[] datas = System.Text.ASCIIEncoding.UTF8.GetBytes(textBox1.Text);
				mqttClient.Publish(topic, datas, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
				Text += "- publist Ok";

			}
			else { Text = "publish falise"; }
	}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}
