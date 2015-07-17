

import org.json.*;

import org.eclipse.jetty.*;

import org.eclipse.jetty.server.Request;
import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.server.handler.*;



import java.io.EOFException;
import java.io.IOException;
import java.io.InputStream;
import java.io.ObjectInputStream;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.concurrent.LinkedBlockingQueue;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * A stateless server process that executes <code>Command</code>s sent to it via
 * clients over TCP. Each incoming TCP client connection is process by one of
 * two <code>Worker</code> threads. The main thread accepts connections and puts
 * them into a blocking queue which are then picked up by a free worker.
 * 
 * The worker then reads serialized <code>Command</code> objects and executes
 * them till the client keeps sending them.
 * 
 * @author Part 
 */



public class HelloWorld extends AbstractHandler
{
    public void handle(String target,
                       Request baseRequest,
                       HttpServletRequest request,
                       HttpServletResponse response) 
        throws IOException, ServletException
    {
        response.setContentType("text/html;charset=utf-8");
        response.setStatus(HttpServletResponse.SC_OK);
        baseRequest.setHandled(true);
        response.getWriter().println("<h1>Hello World</h1>");
    }
 
    public static void main(String[] args) throws Exception
    {
        Server server = new Server(8080);
        server.setHandler(new HelloWorld());
 
        server.start();
        server.join();
    }
}




//public class Server_main {
//	
//	static String convertStreamToString(java.io.InputStream is) {
//	    java.util.Scanner s = new java.util.Scanner(is).useDelimiter("\\A");
//	    return s.hasNext() ? s.next() : "";
//	}
//
//    private ServerSocket serverSock;
//
//    public static void main(String[] args) throws Exception {
//        Server_main processor = new Server_main();
//        processor.start();
//    }
//
//    /**
//     * Open the server socket and start worker threads.
//     * 
//     * @throws Exception
//     */
//    private void start() throws Exception {
//        LinkedBlockingQueue<Socket> queue = new LinkedBlockingQueue<>();
//        serverSock = new ServerSocket(9999);
//        // Can be replaced by a thread pool, not important right now.
//        new Thread(new Worker(queue), "Worker 1").start();
//        new Thread(new Worker(queue), "Worker 2").start();
//        new Thread(new Worker(queue), "Worker 3").start();
//        System.out.println("Server started");
//        while (true) {
//        	
//            queue.put(serverSock.accept());
//            System.out.println("Client accepted");
//        }
//    }
//
//    /**
//     * A thread that pops a client connection to process and starts
//     * deserializing <code>Command</code> objects to execute till the client has
//     * more to send.
//     * 
//     * @author Parth
//     * 
//     */
//    private class Worker implements Runnable {
//        private LinkedBlockingQueue<Socket> socketQueue;
//
//        public Worker(LinkedBlockingQueue<Socket> queue) {
//            this.socketQueue = queue;
//        }
//
//        @Override
//        public void run() {
//            while (true) {
//                try {
//                    Socket clientSocket = socketQueue.take();
//                    System.out.println("Processing requests for " + clientSocket.getRemoteSocketAddress());
//                    
//                    InputStream input = clientSocket.getInputStream();
//                    String message = convertStreamToString(input);
//                    System.out.println(message);
//                    
//                  
//                    }
//                  
//                 catch (IOException e) {
//                    // Woops! Something went wrong with this Socket. Continue
//                    // with the next
//                    // available one.
//                    e.printStackTrace();
//                    
//                
//                } catch (InterruptedException e1) {
//					// TODO Auto-generated catch block
//					e1.printStackTrace();
//					
//                }
//                }
//        }
//    }
//}