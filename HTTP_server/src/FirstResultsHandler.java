import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.eclipse.jetty.server.Request;
import org.eclipse.jetty.server.handler.AbstractHandler;


public class FirstResultsHandler extends AbstractHandler{
	private Results results;

	FirstResultsHandler(){
		results = new Results();
		
	}
	public void handle(String target, Request baseRequest, HttpServletRequest ServletRequest,
			HttpServletResponse ServletResponse) throws IOException, ServletException {
		// TODO Auto-generated method stub
		
		if (isFirstResults(target)){
			return;			
		}
		
		//TODO
//		getStuffFromAsuo(results);
//		getStuffFromBillingSystem(results);
		
		
		encode_results(ServletRequest, results);
		
		
		
		
		
		
		
		
		
		
	}

	private void encode_results(HttpServletRequest servletRequest,
			Results results2) {
		// TODO Auto-generated method stub
		
	}
	private boolean isFirstResults(String target) {
		
		if (target.equals("/***FirstResults"))
			return true;
		return false;
	}

}
