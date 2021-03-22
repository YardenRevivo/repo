
public class Call implements Runnable { 
	private String Address;
	private int area;
	private double Time;
	private int Arrival;
	private int Severity;
	private Dispatcher d; 
	private Object key;  //synchronized object


	public Call (String Address, int area ,int Severity, int Arrival, double Time) {  //constructor
		this.Address =Address; 
		this.Time=Time;
		this.Arrival=Arrival;
		this.area =area;
		this.Severity = Severity;
		new Thread(this).start(); //start the call
	}

	public void run(){
		try {
			Thread.sleep(Arrival*1000); 
			d.addCall(this);
			synchronized(key) { //synchronized between the dispatcher to the call

				key.wait();//the call is waiting until it handled
			}
		}
		catch(InterruptedException eror) {

		}
	}

	public double getTime() {
		return Time;
	}
	public String getAddress() {
		return Address;
	}
	public int getSeverity() {
		return Severity;
	}
	public int getArea() {
		return area;
	}
	public int getArrival() {
		return Arrival;
	}
	public Object getKey() {
		return key;
	}
}