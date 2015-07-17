import java.io.IOException;

import org.eclipse.jetty.servlet.*;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.eclipse.jetty.server.*;
import org.eclipse.jetty.server.handler.AbstractHandler;
import org.eclipse.jetty.server.handler.HandlerList;


public class HTTP_main{
	
	public static void main (String[] args) throws Exception{
		//Start Server		
		Server server = new Server(8080);
		
		//Init handler instances
		Handler param_request_handler = new ParametersRequestHandler();
		Handler FR_handler = new FirstResultsHandler();
		Handler default_handler = new DefaultHandler();
		
		//Init handlers' list,  add handlers
		HandlerList handlers = new HandlerList();
		handlers.addHandler(param_request_handler);
		handlers.addHandler(FR_handler);
		handlers.addHandler(default_handler);
		
		
		//run the server
		server.setHandler(handlers);
		server.start();
		server.join();
		
		
	}
	
}

