   M S B A M L   `   `   `  ����e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2849.39, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  5   	   F BFengShuiKoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FengShuiKoiFengShuiKoi 5   	      FengShuiKoi.BlogWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     5   	   +localclr-namespace:FengShuiKoi     5   	   -   5          � Title$  
BlogWindow��5	   	   $	��700��6   $
��1200��6)    � WindowStartupLocation$ CenterScreen=�6M    � 	Resources 5
         ActionButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell��%�
  &	        '  �    '  �    '  \    '  x	    �� 5   
   " ��6%   .�5      ��  � �� �#3498DB6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 20,8q�6(   �� 5       � ��$ 14(�6)   �� 5       � ��$ Segoe UI)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$
 10,0q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 6��5   !   # z��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5!      	 5"      P� 5#      
 �@J�IsMouseOver$
 True��61   . �5$      ��  � �� �#2980B963   5%      P� 5'      
 � {�$ False��6/   . �5(      ��  � �� �#BDC3C763   �� 5)       � �� �#7F8C8D63   �� 5*       �@�Cursor$ No��6/   �� 5+       �@J�Opacity$	 0.7Q�60   5,      5.      �� 51   
   "  6   .�52      ��  � ��
 �����6+   �� 53       � ��$ 1q�60   �� 54       � �� �#ECECEC6,   �� 55       �@ GridLinesVisibility$
 None=�64   �� 56       �@ RowHeaderWidth$ 0Q�6/   �� 57       �@ CanUserResizeRows$ False��62   �� 58       �@ CanUserAddRows$ False��6/   �� 59       �@ CanUserDeleteRows$ False��62   �� 5:       �@ CanUserReorderColumns$ False��66   �� 5;       �@ CanUserResizeColumns$
 True��65   �� 5<       �@ CanUserSortColumns$
 True��63   �� 5=       �@ SelectionUnit$ FullRow=�6.   �� 5>       �@ AutoGenerateColumns$ False��64   �� 5?       �@ 
IsReadOnly$
 True��6+   �� 5@       � ��$ Segoe UI)�6+   �� 5A       � ��$ 13(�6)   5B      �� 5E   
   "  6   .�5F      ��  � ��
 �����6+   �� 5G       � ��$ 40��6'   	 5H      P� 5I      
 �@J�IsMouseOver$
 True��61   . �5J      ��  � �� �#F5F9FF63   5K      P� 5L      
 �@ 
IsSelected$
 True��60   . �5M      ��  � �� �#EBF5FF63   �� 5N       � �� �#2C3E5063   5O      5Q      �� 5T   
   "  6   .�5U      ��  � �� �#F8F9FA6+   �� 5V       � �� �#2C3E506+   �� 5W       � ��$ SemiBold"�6+   �� 5X       � ��$ 10,12q�6(   �� 5Y       � ��$ 0,0,0,1q�60   �� 5Z       � �� �#ECECEC6,   5[      �� 5^   
   "  6   .�5_      ��  � ��$ 0q�60   �� 5`       � ��$
 10,0q�6(   �� 5a       � �� 5b      �� 5c      "  6&   .R�5d      �� #��z��6!   #��z��5e   !   #��z��5f   !   # z��5g   !   ._�5h      �� 5i      5j      5l      5m      5n      .��5p      � ���#F9FAFB � ColumnDefinitions 5q   
   �� 5r      $	��600 �6   �� 5s      $��* �6   .+�5w   
   � $��0��6    � RowDefinitions 5x      �� 5y      $��80 �6    �� 5z      $��* �6    .+�5~      �� 
����������#ECECEC$��0,0,1,1q�5�      ._�5�      ]� $
��20,0q�6   $��Center=�6*   .+�5�      �� $��
BLOG POSTS��6    $��24(�5�      $
��Bold"�5�      ���#2C3E50$
��Left=�5�      $��Center=�5�      �� 5�       �� Orientation$ 
Horizontal=�6!   $��Right=�5�      $��Right=�5�      .+�5�      �� -   5         ��Name$ btnManageBlog��5�   !   $��MANAGE��5�   !   #��[  5�   !   5�   !   �� 5�      -   5        $ btnBack��5�   !   $
��BACK��5�   !   #��[  5�   !   ���#95A5A65�   !   5�      5�      5�      �� 5�      $��1��6   
����������#ECECEC$��0,0,1,0q�5�      $��0,0,0,0q�5�      ._�5�        -   5          Name$ dgBlogs��5�      $��20q�5�         SelectionMode$ Single=�5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ TITLE��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5�   +   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   +   �� *Title+5�   +     5�      $ CREATED DATE��6-   $	 120 5�   +    5�   +   �� *CreatedDate+ �� StringFormat$ {0:dd/MM/yyyy}��5�   +   5�      5�      5�      � 5�   
   $��1��6    5�      �� 5�      $��80 �6    �� 5�      $��* �6    .+�5�      �� 
����������#ECECEC$��0,0,0,1q�5�      ._�5�      �� -   5         ��Name$ txtCurrentBlog��5�      $��Select a blog to read��5�      $��20(�5�      $��SemiBold"�5�      ���#2C3E50$
��20,0q�5�      $��Center=�5�      5�      )	   #Microsoft.Web.WebView2.Wpf.WebView2	  5�      -   5         	 Name$ webView��5�      $��1��5�      $��0q�5�      5�      5�      5�      