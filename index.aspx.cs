using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Index : System.Web.UI.Page
{
    protected SqlDataReader reader;
    public int PageNumber = 0;
    public bool needsOlderPostLink;
    public bool needsPreviousLink;
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.bgImg = "home-bg.jpg";
        SqlCommand cmd = new SqlCommand("blogIndex", Master.con);
        int postsCount = getPostsCount();
        int pagesCount =  getPageCount(postsCount);

        // Case 1: QueryString dont't has a pagenumber.
        // If there is no PageNumber, then PageNumber should be 1.
        if (Request.QueryString["PageNumber"] == null)
        {
           PageNumber = 1;
        }
        // Case 2: QueryString has a pagenumber.
        // then display the page have existing pagenumber.
        else
        {
            PageNumber = int.Parse(Request.QueryString["PageNumber"].ToString());
        }

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PageNumber", PageNumber);
        cmd.Parameters.AddWithValue("@RowspPage", 5);
        this.reader = cmd.ExecuteReader();
        
        getOlderPostLink(pagesCount);
        getPreviousLink();
    }

    

    private void getPreviousLink()
    {
        if (PageNumber == 1)
        {
            needsPreviousLink = false;
        }
        else
        {
            needsPreviousLink = true;
        }
    }

    private void getOlderPostLink(int pagesCount)
    {
        if (pagesCount == PageNumber)
        {
            needsOlderPostLink = false;
        }
        else
        {
            needsOlderPostLink = true;
        }
    }

    private static int getPageCount(int postsCount)
    {
        int pagesCount;
        // Case 1: Evenly divisible
        if (postsCount % 5 == 0)
        {
            pagesCount = postsCount / 5;
        }
        // Case 2: Floating Point
        else
        {
            pagesCount = (postsCount / 5) + 1;
        }
        return pagesCount;
    }

    protected  int getPostsCount()
    {
        SqlCommand cmd= new SqlCommand();
        cmd.Connection=Master.con;
        cmd.CommandText = "Select count(id) AS postsCount from Blog";
        int postsCount = int.Parse(Convert.ToString(cmd.ExecuteScalar()));
        return postsCount;
    }

    // counting number of comments of postid
    // return total number of comments
    protected string getCommentsCount(string id)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Master.con;
        int nid = int.Parse(id);
        cmd.CommandText = @"
            SELECT count(postid) AS commentsCount 
            FROM Comments 
            WHERE postid = @nid";
        cmd.Parameters.AddWithValue("@nid", nid);
        string result = Convert.ToString(cmd.ExecuteScalar());

        return result;
    }
}