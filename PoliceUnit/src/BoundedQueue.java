import java.util.ArrayList;
public class BoundedQueue <T>  {
	private ArrayList<T> bq;
	private int maxSize ;

	public BoundedQueue (int maxSize) { //constructor
		super();
		bq = new ArrayList <T> (); 
		this.maxSize = maxSize ;
	}

	public synchronized void add (T t) { //add an object to the Bounded Queue list
		while (bq.size() == maxSize)
			try{
				wait();
			}

		catch (InterruptedException e){
		}
		bq.add(t);
		notifyAll();
	}

	public synchronized T extract(Employ Pe) { //extract an object to the Bounded Queue list
		while (bq.isEmpty()  && Pe.isRunning==true) {
			try {
				wait();
			} catch (InterruptedException e) {}
		}

		if(!bq.isEmpty()) {
			T temp = bq.get(0);
			bq.remove(temp);
			return temp;
		}
		else 
			return null; //only if the day is over
	}  
}
