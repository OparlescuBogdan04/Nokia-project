   M S B A M L   `   `   `  ����	  Nokia*    $Nokia.ApplicationPages.BacklogModule   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Backlog Module��5   	   $	��450��6    $	��800��6-   .��5      �    BackgroundGradient#��[  6   .+�5	   
   ��   
BackButton#��[ 6   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
_DataTable��5         AutoGenerateColumns .  $��	64,76,0,0q�6C   $	��Top=�6V   $
��Left=�6n   $	��230��6�   $	��510��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Owner��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Owner+6N     5      $ Status��6%   $ * 6P    65   �� *Status+6P     5      $
 Jira��6%   $ * 6L    63   �� *Jira+6L     5      $ Defect��6%   $ * 6P    65   �� *Defect+6P     5      $ Priority��6%   $ * 6T    67   �� *
Priority+6T   5      �� 5   
   -   5         ��Name$ 
_EditEntry��5      $��
Edit Entry��6%   $��Center=�6:   $��	0,358,0,0q�6W   $	��Top=�6j   $��20��6�   $	��140��6�   6�   �� 5   
   $��Button��6   $
��Left=�6"   $��992,232,0,0q�6=   $	��Top=�6R   $��0��6j   5      5      