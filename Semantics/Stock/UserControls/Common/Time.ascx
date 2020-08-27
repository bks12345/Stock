﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Time.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.Time" %>
<style type="text/css">
/*style for previous form
.common-padding {
    padding-left: 3px !important;
    padding-right: 3px !important;
}*/

/*style for new form*/
.time-div{margin-left:0; margin-right:0;}
.hour, .minute, .ampm {
  float: left;
  width: 33%;
}
</style>
<%--previous form starts--%>
<%--<div class="form-group">
<div class="col-md-4 col-sm-4 col-xs-4 common-padding">
<asp:DropDownList ID="ddlHr" runat="server" CssClass="form-control">
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>1</asp:ListItem>
<asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>8</asp:ListItem>
<asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-md-4 col-sm-4 col-xs-4 common-padding">
<asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control">
<asp:ListItem>00</asp:ListItem>
<asp:ListItem>01</asp:ListItem>
<asp:ListItem>02</asp:ListItem>
<asp:ListItem>03</asp:ListItem>
<asp:ListItem>04</asp:ListItem>
<asp:ListItem>05</asp:ListItem>
<asp:ListItem>06</asp:ListItem>
<asp:ListItem>07</asp:ListItem>
<asp:ListItem>08</asp:ListItem>
<asp:ListItem>09</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>13</asp:ListItem>
<asp:ListItem>14</asp:ListItem>
<asp:ListItem>15</asp:ListItem>
<asp:ListItem>16</asp:ListItem>
<asp:ListItem>17</asp:ListItem>
<asp:ListItem>18</asp:ListItem>
<asp:ListItem>19</asp:ListItem>
<asp:ListItem>20</asp:ListItem>
<asp:ListItem>21</asp:ListItem>
<asp:ListItem>22</asp:ListItem>
<asp:ListItem>23</asp:ListItem>
<asp:ListItem>24</asp:ListItem>
<asp:ListItem>25</asp:ListItem>
<asp:ListItem>26</asp:ListItem>
<asp:ListItem>27</asp:ListItem>
<asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
<asp:ListItem>30</asp:ListItem>
<asp:ListItem>31</asp:ListItem>
<asp:ListItem>32</asp:ListItem>
<asp:ListItem>33</asp:ListItem>
<asp:ListItem>34</asp:ListItem>
<asp:ListItem>35</asp:ListItem>
<asp:ListItem>36</asp:ListItem>
<asp:ListItem>37</asp:ListItem>
<asp:ListItem>38</asp:ListItem>
<asp:ListItem>39</asp:ListItem>
<asp:ListItem>40</asp:ListItem>
<asp:ListItem>41</asp:ListItem>
<asp:ListItem>42</asp:ListItem>
<asp:ListItem>43</asp:ListItem>
<asp:ListItem>44</asp:ListItem>
<asp:ListItem>45</asp:ListItem>
<asp:ListItem>46</asp:ListItem>
<asp:ListItem>47</asp:ListItem>
<asp:ListItem>48</asp:ListItem>
<asp:ListItem>49</asp:ListItem>
<asp:ListItem>50</asp:ListItem>
<asp:ListItem>51</asp:ListItem>
<asp:ListItem>52</asp:ListItem>
<asp:ListItem>53</asp:ListItem>
<asp:ListItem>54</asp:ListItem>
<asp:ListItem>55</asp:ListItem>
<asp:ListItem>56</asp:ListItem>
<asp:ListItem>57</asp:ListItem>
<asp:ListItem>58</asp:ListItem>
<asp:ListItem>59</asp:ListItem>
<asp:ListItem>60</asp:ListItem>
</asp:DropDownList>
</div>
<div class="col-md-4 col-sm-4 col-xs-4 common-padding">
<asp:DropDownList ID="ddlAmPm" runat="server" CssClass="form-control">
<asp:ListItem>AM</asp:ListItem>
<asp:ListItem>PM</asp:ListItem>
</asp:DropDownList>
</div>
</div>--%>
<%--previous form ends--%>


<%--new form starts--%>
<div class="form-group time-div">
<div class="hour">
<asp:DropDownList ID="ddlHr" runat="server" CssClass="form-control">
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>09</asp:ListItem>
<asp:ListItem>08</asp:ListItem>
<asp:ListItem>07</asp:ListItem>
<asp:ListItem>06</asp:ListItem>
<asp:ListItem>05</asp:ListItem>
<asp:ListItem>04</asp:ListItem>
<asp:ListItem>03</asp:ListItem>
<asp:ListItem>02</asp:ListItem>
<asp:ListItem>01</asp:ListItem>
</asp:DropDownList>
</div>
<div class="minute">

<asp:DropDownList ID="ddlMin" runat="server" CssClass="form-control">
<asp:ListItem>00</asp:ListItem>
<asp:ListItem>01</asp:ListItem>
<asp:ListItem>02</asp:ListItem>
<asp:ListItem>03</asp:ListItem>
<asp:ListItem>04</asp:ListItem>
<asp:ListItem>05</asp:ListItem>
<asp:ListItem>06</asp:ListItem>
<asp:ListItem>07</asp:ListItem>
<asp:ListItem>08</asp:ListItem>
<asp:ListItem>09</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>13</asp:ListItem>
<asp:ListItem>14</asp:ListItem>
<asp:ListItem>15</asp:ListItem>
<asp:ListItem>16</asp:ListItem>
<asp:ListItem>17</asp:ListItem>
<asp:ListItem>18</asp:ListItem>
<asp:ListItem>19</asp:ListItem>
<asp:ListItem>20</asp:ListItem>
<asp:ListItem>21</asp:ListItem>
<asp:ListItem>22</asp:ListItem>
<asp:ListItem>23</asp:ListItem>
<asp:ListItem>24</asp:ListItem>
<asp:ListItem>25</asp:ListItem>
<asp:ListItem>26</asp:ListItem>
<asp:ListItem>27</asp:ListItem>
<asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
<asp:ListItem>30</asp:ListItem>
<asp:ListItem>31</asp:ListItem>
<asp:ListItem>32</asp:ListItem>
<asp:ListItem>33</asp:ListItem>
<asp:ListItem>34</asp:ListItem>
<asp:ListItem>35</asp:ListItem>
<asp:ListItem>36</asp:ListItem>
<asp:ListItem>37</asp:ListItem>
<asp:ListItem>38</asp:ListItem>
<asp:ListItem>39</asp:ListItem>
<asp:ListItem>40</asp:ListItem>
<asp:ListItem>41</asp:ListItem>
<asp:ListItem>42</asp:ListItem>
<asp:ListItem>43</asp:ListItem>
<asp:ListItem>44</asp:ListItem>
<asp:ListItem>45</asp:ListItem>
<asp:ListItem>46</asp:ListItem>
<asp:ListItem>47</asp:ListItem>
<asp:ListItem>48</asp:ListItem>
<asp:ListItem>49</asp:ListItem>
<asp:ListItem>50</asp:ListItem>
<asp:ListItem>51</asp:ListItem>
<asp:ListItem>52</asp:ListItem>
<asp:ListItem>53</asp:ListItem>
<asp:ListItem>54</asp:ListItem>
<asp:ListItem>55</asp:ListItem>
<asp:ListItem>56</asp:ListItem>
<asp:ListItem>57</asp:ListItem>
<asp:ListItem>58</asp:ListItem>
<asp:ListItem>59</asp:ListItem>
<%--<asp:ListItem>60</asp:ListItem>--%>
</asp:DropDownList>
</div>
<div class="ampm">

<asp:DropDownList ID="ddlAmPm" runat="server" CssClass="form-control">
<asp:ListItem>AM</asp:ListItem>
<asp:ListItem>PM</asp:ListItem>
</asp:DropDownList>
</div>
</div>
<%--new form starts--%>