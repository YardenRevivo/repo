import java.util.ArrayList;
public class Queue  <T> { 
	private ArrayList<T> q;

	public Queue () {
		super();
		this.q = new ArrayList <T> ();
	}
	public synchronized void add(T t) {
		q.add(t);

	}

	public synchronized T extract(Employ Pe) {
		while (q.isEmpty() && Pe.isRunning == true) { 
			try {
				wait();
			} catch (InterruptedException e) {}
		}
		if(!q.isEmpty()) {
			T temp = q.get(0);
			q.remove(temp);
			return temp;
		}
		else 
			return null; //only if the day is over
	}

	public T get (int i) {
		return q.get(i);
	}
	public int size() {
		if (q == null) return 0;
		return q.size();
	}
	public boolean isEmpty() {
		if (q == null) return true;
		return false;
	}
	public synchronized void wake(){ //wake all the threads
		notifyAll();
	}
}
