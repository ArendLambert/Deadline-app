   M S B A M L   `   `   `  ����F  BDeadLineApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:DeadLineAppDeadLineApp  5   	       DeadLineApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:DeadLineApp     5   	     � Title$  Список задач��5   	   $	��482��6   $	��797��6+   .��5	      �  J� RenderTransformOrigin$ 0.5,0.5&�6   ���	#FFFFE6E6.+�5
   
   �� -   5         ��Name$ 	ListDeals��5
      $��	0,0,346,0q�6%   ���	#FFE3C5C568   �� 5   
   -   5         ��Name$ AddDealButton��5      $��Добавить��6(   $
��Left=�6;   $��474,379,0,0q�6V   $	��Top=�6k   $��45��6�   $	��110��6�   ���	#FFE8D7D7$��Comic Sans MS)�6�   �� 5   
   -   5        $ DeleteDealButton��5      $��Удалить��6+   $
��Left=�6=   $��650,379,0,0q�6X   $	��Top=�6m   $��45��6�   $	��110��6�   ���	#FFE8D7D7$��Comic Sans MS)�6�   �� 5   
   $4��.Сортировка по приоритету��6   $
��Left=�63   $��
456,10,0,0q�6N   $	��Top=�6b   $��Comic Sans MS)�6z   �� 5   
   -   5        $ MinSortButton��5      $	��▲��6(   $
��Left=�64   $��
465,41,0,0q�6O   $	��Top=�6c   $��25��6{   $��25��6�   ���	#FFE8D7D76�   �� 5   
   -   5        $ MaxSortButton��5      $	��▼��6(   $
��Left=�64   $��
495,41,0,0q�6O   $	��Top=�6c   $��25��6{   $��25��6�   ���	#FFE8D7D76�   �� 5   
   -   5        $ ClearSOrtButton��5      $��Очистить��6*   $
��Left=�6=   $��
550,41,0,0q�6X   $	��Top=�6l   $��25��6�   ���	#FFE8D7D7$��Comic Sans MS)�6�   &   System.Windows.Controls.Calendar  5   
   -   5          Name$ MainCalendar��5      $
��Left=�6)   $��
465,98,0,0q�6D   $	��Top=�6X   $��Comic Sans MS)�6p   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFE4EAF0��6#   � 5      $ 	#FFECF0F4��6#    � Offset$
 0.16Q�65   � 5      $ 	#FFFCFCFD��6#   $
 0.16Q�65   � 5      $ 	#FFFFF4F4��6#   $ 1Q�65   5      5      �� 5   
   -   5        	 ��Name$	 SearchTextBox��5      $
��Left=�6)   $��
650,41,0,0q�6D   
 �� TextWrapping$

 Wrap=�6X   $(��"введите что-нибудь��6l   $	��Top=�6�   $	��120��6�   $��25��6�   $��Comic Sans MS)�6�   ���	#FFFFF4F46F  �� 5   
   $��
Поиск��6   $
��Left=�6    $��
650,12,0,0q�6;   $	��Top=�6O   $��25��6g   $��Comic Sans MS)�6s   5      5      