
using System.IO.Ports;
…
public partial class MainForm : Form 
{
    private SerialPort _serialPort;
    private static bool _continue;
    protected static string curr_module_name;
    protected static uint curr_language;
    protected static int curr_volume;
    protected static int curr_pitch;
    protected static int curr_speech_rate;

    Thread readThread = new Thread(Read);

    static public void Read()
    {
        while (_continue)
        {
            try
            {
                string message = _serialPort.ReadLine();
                Console.WriteLine(message);
                VoiceSynthesis.Speak(curr_module_name, (int)curr_language, message, curr_volume, curr_pitch, curr_speech_rate);
            }
            catch (TimeoutException) { }
        }
    }

    public MainForm(PXCMSession session)
    {
        …
        _serialPort = new SerialPort();
        _serialPort.PortName = "COM16"; //Serial port Edison is connected to
        _serialPort.BaudRate = 9600;
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
    
        _serialPort.Open();
        _continue = true;
        readThread.Start();
    }
    
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _continue = false;
        readThread.Join();
        _serialPort.Close();
    }
    …   
}

