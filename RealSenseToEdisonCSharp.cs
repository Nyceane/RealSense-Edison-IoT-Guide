
using System.IO.Ports;
…
public partial class MainForm : Form 
{
	private SerialPort _serialPort;
    private int _lastGesture;
	…
    public MainForm(PXCMSession session) 
    {
    	…
    	_serialPort = new SerialPort();
        _serialPort.PortName = "COM16"; //Serial port Edison is connected to
        _serialPort.BaudRate = 9600;
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
    }

    private void WriteToSerialPort(int value)
    {
        if (_lastGesture != write)
        {
            Console.WriteLine(write.ToString());
            _serialPort.Write(write.ToString());
        }
        _lastGesture = write;
    }

    public void UpdateInfo(string status,Color color)
    {
    …

        if (status.Contains("spreadfingers") || status.Contains("spreadfingers"))
        {
            WriteToSerialPort(1);
        }
        else
        {
            WriteToSerialPort(0);
        }          
     }

    private void Start_Click(object sender, EventArgs e)
    {
                …
        _serialPort.Open();
    }

    private void Stop_Click(object sender, EventArgs e)
    {
        …
        _serialPort.Close();
    }

