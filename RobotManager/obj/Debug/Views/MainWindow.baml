   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   G CRobotManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RobotManagerRobotManager 5	   	   A%clr-namespace:RobotManager.ConvertersRobotManager.Converters 5
   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	      RobotManager.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   ,localclr-namespace:RobotManager     5	   	   <
converters%clr-namespace:RobotManager.Converters     5
   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   -   5          � Title$  Robot Manager��5   	   $	��600��6   $	��800��6,    � 	Resources 5      =  7RobotManager.Converters.MagnitudeToFeatureNameConverter   M2FConverter2  ,RobotManager.Converters.BoolToColorConverter  B2CConverter  	SkillCell �� 
TargetType*  $System.Windows.Controls.DataGridCell �� BasedOn �� Property �� Value �� Path �� 	Converter��%�   &	        &	      &	 &     7 7    5   
   65     5   
   6*   �� 5   
   "  6"   8   .�5      ��  � �� 6+   �� $ 
IsPossible�8  �� 5       � ��$ Center=�69   �� 5       � ��$ Center=�6;   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5       $��* �6   �� 5!      $
��1.5* �6   �� 5"      $��* �6   	 � RowDefinitions	 5$   
   �� 5%      $	��100 �6   �� 5&      $��* �6   .+�5)   
   �� $��Add new robot��6   $��0��6U   $��0��6b   $	��Top=�6r   $
��Left=�6�   ��6)   �� $ AddNewRobotCommand�6�   �� 5*   
   $��Modify selected robot��6   $��0��6e   $��1��6r   $	��Top=�6�   $
��Left=�6�   ��61   �� $  ModifySelectedRobotCommand�6�   �� 5+   
   $��Delete selected robot��6   $��0��6e   $��2��6r   $	��Top=�6�   $
��Left=�6�   ��61   �� $  DeleteSelectedRobotCommand�6�   &   System.Windows.Controls.DataGrid  5,   
   
 J� IsHitTestVisible
 .     
IsReadOnly . $��Center=�6o   $��1��6�   $��2��6�      AutoGenerateColumns .  ��6>   �� *SelectedRobot.SkillsList+   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Skill��6%      	CellStyle# [ 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Name+6M   50        52   
    . $��Center=�6k   $��1��6�   $��1��6�    .   �� SelectedItem 6%   �� *SelectedRobot+��6L   �� *Robots+ 53        54      $
 Name��6%    63   �� *Name+  55      $ 
Group Name��6%    69   �� *	GroupName+  56      $ Group ID��6%    67   �� *	GroupID+58        59   
   
 .   . $��Center=�6q   $��1��6�   $��0��6�    .  ��6>   �� *SelectedRobot.FeaturesList+ 5:        5;      $ Feature��6%    66   �� *Name+4  .System.Windows.Controls.DataGridTemplateColumn  5<      $ Value��6)      CellTemplate 5=      �� 5>      .R�5?      � $	��100��6x   $��Center=�6�   $��1��6�    � Minimum$ 0Q�6�    � Maximum$ 5Q�6�    � ToolTip 6*   �� $ 	Magnitude�# [   � Value 6�   �� *	Magnitude+5@      5B      5D      5F      5I      