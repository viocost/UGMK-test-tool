import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.eclipse.jetty.server.Request;
import org.eclipse.jetty.server.handler.AbstractHandler;

import sun.net.util.IPAddressUtil;


public class ParametersRequestHandler extends AbstractHandler{

	public void handle(String target, Request base_request, HttpServletRequest servlet_request,
			HttpServletResponse servlet_response) throws IOException, ServletException {
		
		if (!isParametersRequest(target)){
			System.out.println("Wrong request!");
			return;
		}
		
		
		
		servlet_response.setContentType("text/html;charset=utf-8");
        servlet_response.setStatus(HttpServletResponse.SC_CREATED);
        String remoteHost = servlet_request.getRemoteAddr();
        base_request.setHandled(true);
        servlet_response.getWriter().println("<h2>Hello World</h2>");
        System.out.println("Got a connection from "+remoteHost+" "+target);
		

		
	}

	private boolean isParametersRequest(String target) throws IOException {
		// TODO Auto-generated method stub
		
		if(target.equals("/target"))
				return true;
		return false;
	}

}
