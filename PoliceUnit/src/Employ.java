
abstract public class Employ { 
	protected String name; 
	protected boolean isRunning;
	
	public Employ(String name, boolean run) { //constructor
		this.name=name;
		isRunning=run;
	}

	public void isRunning(boolean b) { //check if the thread still running
		this.isRunning=false;
	}
}
